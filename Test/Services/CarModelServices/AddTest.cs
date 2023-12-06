using Application.Functions.CarModels.Commands.Add;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Services.CarModelServices
{
    public class AddTest : BaseTest
    {
        [Fact]
        public async Task CarModel_Add_IsOk()
        {
            var _query = new Application.Functions.CarModels.Queries.GetAll.GetAllCarModelsQuery();
            var _handlerForAllModels = new Application.Functions.CarModels.Queries.GetAll.GetAllCarModelsHandler(_carModelRepository.Object, _mapper);

            var allModels = await _handlerForAllModels.Handle(_query, default);

            var command = new AddCarModelCommand("Bmw", "E91");
            var handler = new AddCarModelHandler(_mapper, _carModelRepository.Object);

            var result = await handler.Handle(command, default);
            
            var allModelsAfterAddedNew = await _handlerForAllModels.Handle(_query, default);

            result.IsSuccess.ShouldBeTrue();
            allModelsAfterAddedNew.Data.Count.ShouldBe(allModels.Data.Count + 1);

            //var command = 
        }
    }
}
