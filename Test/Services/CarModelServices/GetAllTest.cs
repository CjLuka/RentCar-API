using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Services.CarModelServices
{
    public class GetAllTest : BaseTest
    {
        [Fact]
        public async Task CarModel_GetAll_IsOk()
        {
            var _query = new Application.Functions.CarModels.Queries.GetAll.GetAllCarModelsQuery();
            var _handler = new Application.Functions.CarModels.Queries.GetAll.GetAllCarModelsHandler(_carModelRepository.Object, _mapper);

            var result = await _handler.Handle(_query, default);

            result.IsSuccess.ShouldBeTrue();
            result.Data.Count.ShouldBe(3);
        }
    }
}
