using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using Caliburn.Micro;

namespace Compost.Caliburn
{
    /// <summary>
    ///     A collection of customizations to enhance the caliburn.micro framework.
    /// </summary>
    public static class CaliburnCustomizations
    {
        private static readonly string[] ParameterNames =
            MessageBinder.SpecialValues.Keys.Select(k => k.ToLower().Trim('$')).ToArray();

        private static readonly Dictionary<string, DependencyProperty> CommonDependencyProperties =
            new Dictionary<string, DependencyProperty>();

        /// <summary>
        ///     This customization adds two enhancements to the automatic binding in caliburn micro.
        ///     <para>
        ///         First, this adds automatic binding of properties in the view model by leveraging the standard caliburn
        ///         micro conventions. If an element named "UserName" is in the view and a property named "UserNameVisibility" is
        ///         in the view model, the visibility property of the view element will be bound to to the view model property.
        ///         Another important addition here is that if a custom view of type "SettingsView" named "Settings" is used within
        ///         a parent view, then the corresponding property of type "SettingsViewModel" or "ISettingsViewModel" named
        ///         "Settings" within the parent view model will be bound as a view model using caliburn.micro's View.Model
        ///         property. The automatic binding of view models will occur as long as the view model property is a class of type
        ///         <seealso cref="PropertyChangedBase" />, a class that inherits from <seealso cref="PropertyChangedBase" />,
        ///         an interface of type <seealso cref="INotifyPropertyChangedEx" />, or an interface that implements
        ///         <seealso cref="INotifyPropertyChangedEx" />.
        ///     </para>
        ///     <para>
        ///         Second, this adds automatic binding of methods in the view model to events of the view element by leveraging
        ///         the standard caliburn micro conventions. If an element named "Title" is in the view and a method named
        ///         "TitleMouseEnter" is in the view model, the MouseEnter event will be bound to the TitleMouseEnter method. This
        ///         autobinding also supports the special parameters that caliburn.micro supports for event binding, such as
        ///         'eventArgs' and 'view'. Simply name the parameters in the view model method using the keywords.
        ///     </para>
        ///     <para>These automatic additions do not override or interfere with the standard caliburn.micro conventions.</para>
        /// </summary>
        public static void AddAutomaticPropertyAndEventBindings()
        {
            var baseBindingFunction = ViewModelBinder.Bind;
            ViewModelBinder.Bind = (viewModel, view, context) =>
            {
                baseBindingFunction(viewModel, view, context);
                BindPropertiesOfNamedElements(viewModel, view);
                BindEventsOfNamedElements(viewModel, view);
            };
        }

        private static void BindPropertiesOfNamedElements(object viewModel, DependencyObject view)
        {
            var frameworkElement = View.GetFirstNonGeneratedView(view) as FrameworkElement;
            if (frameworkElement == null) return;

            var viewModelType = viewModel.GetType();
            var namedElements = BindingScope.GetNamedElements(frameworkElement);

            BindProperties(namedElements, viewModelType);
        }

        private static void BindProperties(IEnumerable<FrameworkElement> namedElements, Type viewModelType)
        {
            const BindingFlags flags = BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance;
            var properties = viewModelType.GetProperties(flags);

            foreach (var element in namedElements)
            {
                var trimmed = element.Name.Trim('_');
                var parts = trimmed.Split(new[] {'_'}, StringSplitOptions.RemoveEmptyEntries);
                var baseElementName = parts[0];

                var matchingProperties = properties.Where(p => p.Name.StartsWith(baseElementName));

                foreach (var matchingProperty in matchingProperties)
                {
                    var dp = GetDependencyProperty(element, matchingProperty, baseElementName);

                    if (dp != null)
                        ConventionManager.SetBinding(viewModelType, matchingProperty.Name, matchingProperty, element,
                            null, dp);
                }
            }
        }

        private static DependencyProperty GetDependencyProperty(FrameworkElement element, PropertyInfo matchingProperty,
            string baseElementName)
        {
            if (matchingProperty.Name.Equals(baseElementName))
                return IsViewModel(matchingProperty) ? View.ModelProperty : null;

            var dependencyPropertyName = matchingProperty.Name.Remove(0, baseElementName.Length);
            var fieldName = dependencyPropertyName + "Property";

            if (CommonDependencyProperties.ContainsKey(fieldName))
                return CommonDependencyProperties[fieldName];

            var dp = UseReflectionToFindDependencyProperty(element, fieldName);
            CommonDependencyProperties.Add(fieldName, dp);
            return dp;
        }

        private static bool IsViewModel(PropertyInfo matchingProperty)
        {
            return matchingProperty.PropertyType.GetInterfaces().Any(i => i == typeof (INotifyPropertyChangedEx)) ||
                   matchingProperty.PropertyType.IsAssignableFrom(typeof (PropertyChangedBase)) ||
                   matchingProperty.PropertyType == typeof (PropertyChangedBase);
        }

        private static DependencyProperty UseReflectionToFindDependencyProperty(FrameworkElement element,
            string fieldName)
        {
            var type = element.GetType();
            FieldInfo fieldInfo;

            do
            {
                fieldInfo = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Static);
                type = type.BaseType;
            } while (fieldInfo == null && type != null);

            if (fieldInfo == null)
                throw new Exception("Could not find the the " + fieldName + " property on element of type " +
                                    element.GetType().Name);

            return (DependencyProperty) fieldInfo.GetValue(element);
        }

        private static void BindEventsOfNamedElements(object viewModel, DependencyObject view)
        {
            var frameworkElement = View.GetFirstNonGeneratedView(view) as FrameworkElement;
            if (frameworkElement == null) return;

            var viewModelType = viewModel.GetType();
            var namedElements = BindingScope.GetNamedElements(frameworkElement);

            var methods = viewModelType.GetMethods(BindingFlags.Public | BindingFlags.Instance);

            foreach (var element in namedElements)
            {
                var trimmed = element.Name.Trim('_');
                var parts = trimmed.Split(new[] {'_'}, StringSplitOptions.RemoveEmptyEntries);
                var baseElementName = parts[0];

                var matchingMethods = methods
                    .Where(p => p.Name.StartsWith(baseElementName) && !p.Name.Equals(baseElementName));

                foreach (var matchingMethod in matchingMethods)
                {
                    var eventName = matchingMethod.Name.Replace(element.Name, "");
                    if (element.GetType().GetEvent(eventName) != null)
                        Message.SetAttach(element, CreateEventString(matchingMethod, element));
                }
            }
        }

        private static string CreateEventString(MethodInfo matchingMethod, FrameworkElement element)
        {
            var paramsString = CreateParametersString(matchingMethod);
            var methodString = matchingMethod.Name + paramsString;
            var eventName = matchingMethod.Name.Replace(element.Name, "");

            var eventString = string.Format("[Event {0}]=[Action {1}]", eventName, methodString);

            var currentEventString = Message.GetAttach(element);
            if (!string.IsNullOrWhiteSpace(currentEventString))
                eventString = currentEventString + ";" + eventString;

            return eventString;
        }

        private static string CreateParametersString(MethodInfo matchingMethod)
        {
            var parameters = matchingMethod.GetParameters();

            foreach (var parameter in parameters)
                if (!ParameterNames.Any(paramName => paramName.Equals(parameter.Name.ToLower())))
                    throw new InvalidParameterNameException(matchingMethod, parameter);

            var paramsString = parameters.Aggregate("", (t, p) => t + ", $" + p.Name).Trim(' ', ',');
            if (!paramsString.Equals(""))
                paramsString = "(" + paramsString + ")";

            return paramsString;
        }

        /// <summary>
        ///     This exception is thrown when an invalid parameter name is used when auto binding to a method in the view model.
        /// </summary>
        public class InvalidParameterNameException : Exception
        {
            private const string MESSAGE_FORMAT =
                @"Failed to bind method {0} in type {1}. The parameter name '{2}' is invalid. Valid parameter names for an automatically bound method include: [{3}]";

            private static readonly string ValidParameterNames = ParameterNames.Aggregate((t, c) => t + ", " + c);

            /// <summary>
            ///     Creates an instance with a message describing the method cotaining the invalid parameter name.
            /// </summary>
            /// <param name="methodInfo"></param>
            /// <param name="parameterInfo"></param>
            public InvalidParameterNameException(MethodInfo methodInfo, ParameterInfo parameterInfo)
                : base(
                    // ReSharper disable once PossibleNullReferenceException
                    string.Format(MESSAGE_FORMAT, methodInfo.Name, methodInfo.DeclaringType.FullName, parameterInfo.Name,
                        ValidParameterNames)) {}
        }
    }
}