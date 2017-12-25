using System;
using System.ComponentModel.DataAnnotations;
using Bit0.Utils.Common.Exceptions;
using Bit0.Utils.Data.Reference;
using Bit0.Utils.Data.Repositories;

namespace Bit0.Utils.Data.Http.Attributes
{
    /// <summary>
    /// Validate data
    /// </summary>
    public class DataValidation : DataTypeAttribute
    {
        /// <summary>
        /// Validate data
        /// </summary>
        public DataValidation()
            : base("Data")
        { }

        /// <inheritdoc />
        protected override ValidationResult IsValid(Object value, ValidationContext validationContext)
        {
            var dataRepository = validationContext.GetService(typeof(IDataRepository<IData>)) as IDataRepository<IData>;

            DataReference id = value as string;

            ValidationResult validationResult;
            try
            {
                if (dataRepository == null)
                {
                    throw new NullObjectException(nameof(dataRepository));
                }

                dataRepository.GetById<IData>(id);
                validationResult = ValidationResult.Success;
            }
            catch (Exception)
            {
                validationResult = new ValidationResult(FormatErrorMessage(ErrorMessage));
            }

            return validationResult;
        }
    }
}
