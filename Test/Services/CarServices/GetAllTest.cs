using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Services.CarServices
{
    public class GetAllTest : BaseTest
    {
        [Fact]
        public async Task Cars_GetAll_IsOk()
        {
            var _query = new Application.Functions.Cars.Queries.GetAll.GetAllCarsQuery();

            var _handler = new Application.Functions.Cars.Queries.GetAll.GetAllCarsHandler(_carRepository.Object, _mapper);
            var result = await _handler.Handle(_query, default);

            result.IsSuccess.ShouldBeTrue();
            result.Data.Count.ShouldBe(6);
        }
    }
}
