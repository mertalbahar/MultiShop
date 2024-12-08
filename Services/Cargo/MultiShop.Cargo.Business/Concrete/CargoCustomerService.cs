using AutoMapper;
using MultiShop.Cargo.Business.Abstract;
using MultiShop.Cargo.DataAccess.Abstract;
using MultiShop.Cargo.Dto.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.Entity.Concrete;

namespace MultiShop.Cargo.Business.Concrete;

public class CargoCustomerService : ICargoCustomerService
{
    private readonly IRepositoryManager _manager;
    private readonly IMapper _mapper;

    public CargoCustomerService(IRepositoryManager manager, IMapper mapper)
    {
        _manager = manager;
        _mapper = mapper;
    }

    public void DeleteCargoCustomer(int id)
    {
        CargoCustomer cargoCustomer = _manager.CargoCustomerRepository.Get(x => x.Id.Equals(id));
        _manager.CargoCustomerRepository.Delete(cargoCustomer);
    }

    public List<ResultCargoCustomerDto> GetAllCargoCustomer()
    {
        IList<CargoCustomer> listedCargoCustomer = _manager.CargoCustomerRepository.GetList();
        List<ResultCargoCustomerDto> result = _mapper.Map<List<ResultCargoCustomerDto>>(listedCargoCustomer);

        return result;
    }

    public GetByIdCargoCustomerDto GetByIdCargoCustomer(int id)
    {
        CargoCustomer cargoCustomer = _manager.CargoCustomerRepository.Get(x => x.Id.Equals(id));
        GetByIdCargoCustomerDto result = _mapper.Map<GetByIdCargoCustomerDto>(cargoCustomer);

        return result;
    }

    public void CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
    {
        CargoCustomer cargoCustomer = _mapper.Map<CargoCustomer>(createCargoCustomerDto);
        _manager.CargoCustomerRepository.Add(cargoCustomer);
    }

    public void UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
    {
        CargoCustomer getCargoCustomer = _manager.CargoCustomerRepository.Get(x => x.Id.Equals(updateCargoCustomerDto.Id));
        CargoCustomer mappedCargoCustomer = _mapper.Map(updateCargoCustomerDto, getCargoCustomer);
        _manager.CargoCustomerRepository.Update(mappedCargoCustomer);
    }

    public GetByIdCargoCustomerDto GetByUserIdCargoCustomer(string id)
    {
        CargoCustomer getCargoCustomer = _manager.CargoCustomerRepository.Get(x => x.UserId.Equals(id));
        GetByIdCargoCustomerDto result = _mapper.Map<GetByIdCargoCustomerDto>(getCargoCustomer);

        return result;
    }
}