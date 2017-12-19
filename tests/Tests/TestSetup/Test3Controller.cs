using Bit0.Utils.Data.Http.Attributes;
using Bit0.Utils.Http.Exceptions;
using Bit0.Utils.Http.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using Bit0.Utils.Data;
using Bit0.Utils.Data.Repositories;

namespace Bit0.Utils.Tests.TestSetup
{
    public class Test3Controller : ControllerBase
    {

        private readonly IDataRepository<DataModel> _repository;

        public Test3Controller(IDataRepository<DataModel> repository)
        {
            _repository = repository;

            var data = new DataModel
            {
                Id = "43b5709c-0603-45f3-bbb0-149e999576d0"
            };

            _repository.Save(data);
        }

        [HttpPost]
        [ValidateModel]
        public IActionResult Data([FromBody] DataViewModel model)
        {
            if (ModelState.IsValid)
            {
                return Ok();
            }

            throw new ModelValidationException(new
            {
                model
            });
        }

        public class DataViewModel
        {
            [DataValidation]
            public String Id { get; set; }
        }
        
        public class DataModel : IData
        {
            public String Id { get; set; }
            public DateTime CreatedOn { get; set; } = DateTime.Now;
            public DateTime UpdatedOn { get; set; } = DateTime.Now;
        }
    }
}
