using MultiShop.WebUI.Services.Abstracts;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.CargoServices.CargoCompanyServices;
using MultiShop.WebUI.Services.CargoServices.CargoCustomerServices;
using MultiShop.WebUI.Services.CatalogServices.AboutServices;
using MultiShop.WebUI.Services.CatalogServices.BrandServices;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using MultiShop.WebUI.Services.CatalogServices.DiscountOfferServices;
using MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices;
using MultiShop.WebUI.Services.CatalogServices.ProductDetailServices;
using MultiShop.WebUI.Services.CatalogServices.ProductImageServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices;
using MultiShop.WebUI.Services.CommentServices.ContactServices;
using MultiShop.WebUI.Services.CommentServices.UserCommentServices;
using MultiShop.WebUI.Services.DiscountServices;
using MultiShop.WebUI.Services.IdentityServices;
using MultiShop.WebUI.Services.MessageServices;
using MultiShop.WebUI.Services.OrderServices.OrderAddressServices;
using MultiShop.WebUI.Services.OrderServices.OrderingServices;

namespace MultiShop.WebUI.Services.Concretes
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IClientCredentialsTokenService> _clientCredentialsTokenService;

        // Catalog Microservice
        private readonly Lazy<ICategoryService> _categoryService;
        private readonly Lazy<IProductService> _productService;
        private readonly Lazy<IAboutService> _aboutService;
        private readonly Lazy<IBrandService> _brandService;
        private readonly Lazy<IFeatureSliderService> _featureSliderService;
        private readonly Lazy<IDiscountOfferService> _discountOfferService;
        private readonly Lazy<ISpecialOfferService> _specialOfferService;
        private readonly Lazy<IProductDetailService> _productDetailService;
        private readonly Lazy<IProductImageService> _productImageService;

        // Comment Microservice
        private readonly Lazy<IUserCommentService> _userCommentService;
        private readonly Lazy<IContactService> _contactService;

        // Identity Microservice
        private readonly Lazy<IUserService> _userService;

        // Basket Microservice
        private readonly Lazy<IBasketService> _basketService;

        // Discount Microservice
        private readonly Lazy<IDiscountService> _discountService;

        // Order Microservice
        private readonly Lazy<IOrderAddressService> _orderAddressService;
        private readonly Lazy<IOrderingService> _orderingService;

        // Message Microservice
        private readonly Lazy<IMessageService> _messageService;

        // Cargo Microservice
        private readonly Lazy<ICargoCompanyService> _cargoCompanyService;
        private readonly Lazy<ICargoCustomerService> _cargoCustomerService;

        public ServiceManager(IClientCredentialsTokenService clientCredentialsTokenService,
            ICategoryService categoryService, IProductService productService, IAboutService aboutService,
            IBrandService brandService, IFeatureSliderService featureSliderService, IDiscountOfferService discountOfferService,
            ISpecialOfferService specialOfferService, IProductDetailService productDetailService, IProductImageService productImageService,
            IUserCommentService userCommentService, IContactService contactService, IUserService userService, IBasketService basketService,
            IDiscountService discountService, IOrderAddressService orderAddressService, IOrderingService orderingService,
            IMessageService messageService, ICargoCompanyService cargoCompanyService, ICargoCustomerService cargoCustomerService)
        {
            _clientCredentialsTokenService = new Lazy<IClientCredentialsTokenService>(() => clientCredentialsTokenService);

            // Catalog Microservice
            _categoryService = new Lazy<ICategoryService>(() => categoryService);
            _productService = new Lazy<IProductService>(() => productService);
            _aboutService = new Lazy<IAboutService>(() => aboutService);
            _brandService = new Lazy<IBrandService>(() => brandService);
            _featureSliderService = new Lazy<IFeatureSliderService>(() => featureSliderService);
            _discountOfferService = new Lazy<IDiscountOfferService>(() => discountOfferService);
            _specialOfferService = new Lazy<ISpecialOfferService>(() => specialOfferService);
            _productDetailService = new Lazy<IProductDetailService>(() => productDetailService);
            _productImageService = new Lazy<IProductImageService>(() => productImageService);

            // Comment Microservice
            _userCommentService = new Lazy<IUserCommentService>(() => userCommentService);
            _contactService = new Lazy<IContactService>(() => contactService);

            // Identity Microservice
            _userService = new Lazy<IUserService>(() => userService);

            // Basket Microservice
            _basketService = new Lazy<IBasketService>(() => basketService);

            // Discount Microservice
            _discountService = new Lazy<IDiscountService>(() => discountService);

            // Order Microservice
            _orderAddressService = new Lazy<IOrderAddressService>(() => orderAddressService);
            _orderingService = new Lazy<IOrderingService>(() => orderingService);

            // Message Microservice
            _messageService = new Lazy<IMessageService>(() => messageService);

            // Cargo Microservice
            _cargoCompanyService = new Lazy<ICargoCompanyService>(() => cargoCompanyService);
            _cargoCustomerService = new Lazy<ICargoCustomerService>(() => cargoCustomerService);
        }

        public IClientCredentialsTokenService ClientCredentialsTokenService => _clientCredentialsTokenService.Value;

        // Catalog Microservice
        public ICategoryService CategoryService => _categoryService.Value;

        public IProductService ProductService => _productService.Value;

        public IAboutService AboutService => _aboutService.Value;

        public IBrandService BrandService => _brandService.Value;

        public IFeatureSliderService FeatureSliderService => _featureSliderService.Value;

        public IDiscountOfferService DiscountOfferService => _discountOfferService.Value;

        public ISpecialOfferService SpecialOfferService => _specialOfferService.Value;

        public IProductDetailService ProductDetailService => _productDetailService.Value;

        public IProductImageService ProductImageService => _productImageService.Value;

        // Comment Microservice
        public IUserCommentService UserCommentService => _userCommentService.Value;

        public IContactService ContactService => _contactService.Value;

        // Identity Microservice
        public IUserService UserService => _userService.Value;

        // Basket Microservice
        public IBasketService BasketService => _basketService.Value;

        // Discount Microservice
        public IDiscountService DiscountService => _discountService.Value;

        // Order Microservice
        public IOrderAddressService OrderAddressService => _orderAddressService.Value;

        public IOrderingService OrderingService => _orderingService.Value;

        // Message Microservice
        public IMessageService MessageService => _messageService.Value;

        // Cargo Microservice
        public ICargoCompanyService CargoCompanyService => _cargoCompanyService.Value;

        public ICargoCustomerService CargoCustomerService => _cargoCustomerService.Value;
    }
}
