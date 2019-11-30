using AutoMapper;
using CarDealer.Dtos.Import;
using CarDealer.Dtos.Export;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<ImportSupplierDto, Supplier>();

            this.CreateMap<ImportPartDto, Part>();

            this.CreateMap<ImportCarDto, Car>();

            this.CreateMap<ImportCustomerDto, Customer>();

            this.CreateMap<ImportSaleDto, Sale>();

            this.CreateMap<Car, ExportCarsWithDistanceDto>();

            this.CreateMap<Supplier, ExportLocalSuppliersDto>();
                // If additional mapping is needed
                //.ForMember(x => x.PartsCount, y => y.MapFrom(x => x.Parts.Count));
        }
    }
}
