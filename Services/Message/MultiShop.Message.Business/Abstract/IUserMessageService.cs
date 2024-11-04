using MultiShop.Message.Dto.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Message.Business.Abstract
{
    public interface IUserMessageService
    {
        Task<List<ResultUserMessageDto>> GetAllUserMessageAsync();
        Task<GetByIdUserMessageDto> GetByIdUserMessageAsync(int id);
        Task<List<ResultInboxUserMessageDto>> GetInboxUserMessageAsync(string receiverId);
        Task<List<ResultSendboxUserMessageDto>> GetSendboxUserMessageAsync(string senderId);
        Task CreateUserMessageAsync(CreateUserMessageDto createUserMessageDto);
        Task UpdateUserMessageAsync(UpdateUserMessageDto updateUserMessageDto);
        Task DeleteUserMessageAsync(int id);
    }
}
