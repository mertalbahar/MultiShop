﻿using MultiShop.DtoLayer.MessageDtos;

namespace MultiShop.WebUI.Services.MessageServices
{
    public interface IMessageService
    {
        Task<List<ResultInboxUserMessageDto>> GetAllInboxMessagesAsync(string receiverId);
    }
}
