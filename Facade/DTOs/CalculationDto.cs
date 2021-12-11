using Facade.Services.Displays;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Facade.DTOs
{
    /// <summary>
    /// The DTO to pass numbers to calculate.
    /// </summary>
    public sealed class CalculationDto<T>
    {
        /// <summary>
        /// Gets or sets the text version of comma separated numbers to add.
        /// </summary>
        public string NumbersToAddText { get; set; }

        /// <summary>
        /// Gets or sets the numbers to add.
        /// </summary>
        public T[] NumbersToAdd => SplitInputText(this.NumbersToAddText);

        /// <summary>
        /// Gets or sets the text version of comma separated numbers to multiply.
        /// </summary>
        public string NumbersToMultiplyText { get; set; }

        /// <summary>
        /// Gets or sets the numbers to multiply.
        /// </summary>
        public T[] NumbersToMultiply => SplitInputText(this.NumbersToMultiplyText);

        /// <summary>
        /// Gets or sets the flag to determine whether the result should be rounded up.
        /// </summary>
        public bool UseRoundUp { get; set; }

        /// <summary>
        /// Gets or sets the display mode.
        /// </summary>
        public DisplayModeEnums DisplayMode { get; set; }

        /// <summary>
        /// Converts a string input into a double array.
        /// </summary>
        /// <param name="input">The original text input.</param>
        /// <returns>The array of numbers.</returns>
        private static T[] SplitInputText(string input)
        {
            if (String.IsNullOrWhiteSpace(input))
            {
                return default;
            }

            string[] splittedElements = input.Split(',');
            List<T> validNumbers = new();
            
            for (int index = 0; index < splittedElements.Length; index++)
            {
                if (TryConvertToGeneric(splittedElements[index].Trim(), out T value))
                {
                    validNumbers.Add(value);
                }
            }

            return validNumbers.ToArray();
        }

        /// <summary>
        /// Tries to parse given input into a generic type.
        /// </summary>
        /// <typeparam name="T">The generic type to convert value into.</typeparam>
        /// <param name="input">The source text input value.</param>
        /// <returns>The value converted to generic.</returns>
        private static bool TryConvertToGeneric(string input, out T value)
        {
            value = default;

            try
            {
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
                if (converter != null)
                {
                    value = (T)converter.ConvertFromString(input.Replace('.', ','));
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
