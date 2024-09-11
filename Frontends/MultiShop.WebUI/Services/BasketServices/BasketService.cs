using MultiShop.DtoLayer.BasketDtos;

namespace MultiShop.WebUI.Services.BasketServices
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;

        public BasketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddBasketItem(BasketItemDto basketItemDto)
        {
            BasketTotalDto values = await GetBasket();

            if (values != null)
            {
                if (!values.BasketItems.Any(x => x.ProductId.Equals(basketItemDto.ProductId)))
                {
                    values.BasketItems.Add(basketItemDto);
                }
                else
                {
                    values = new BasketTotalDto();
                    values.BasketItems.Add(basketItemDto);
                }
            }
            await SaveBasket(values);
        }

        public Task DeleteBasket(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<BasketTotalDto> GetBasket()
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync("baskets");
            BasketTotalDto result = await responseMessage.Content.ReadFromJsonAsync<BasketTotalDto>();

            return result;
        }

        public async Task<bool> RemoveBasketItem(string productId)
        {
            BasketTotalDto values = await GetBasket();
            BasketItemDto deletedItem = values.BasketItems.FirstOrDefault(x => x.ProductId.Equals(productId));
            var result = values.BasketItems.Remove(deletedItem);
            await SaveBasket(values);

            return true;
        }

        public async Task SaveBasket(BasketTotalDto basketTotalDto)
        {
            await _httpClient.PostAsJsonAsync<BasketTotalDto>("baskets", basketTotalDto);
        }
    }
}
