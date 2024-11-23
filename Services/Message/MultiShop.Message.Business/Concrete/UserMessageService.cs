using AutoMapper;
using MultiShop.Message.Business.Abstract;
using MultiShop.Message.DataAccess.Abstract;
using MultiShop.Message.Dto.Dtos;
using MultiShop.Message.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Message.Business.Concrete
{
    public class UserMessageService : IUserMessageService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        public UserMessageService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task CreateUserMessageAsync(CreateUserMessageDto createUserMessageDto)
        {
            UserMessage mappedUserMessage = _mapper.Map<UserMessage>(createUserMessageDto);
            await _manager.UserMessageRepository.AddAsync(mappedUserMessage);
        }

        public async Task DeleteUserMessageAsync(int id)
        {
            UserMessage userMessage = await _manager.UserMessageRepository.GetAsync(x => x.Id.Equals(id));
            await _manager.UserMessageRepository.DeleteAsync(userMessage);
        }

        public async Task<List<ResultUserMessageDto>> GetAllUserMessageAsync()
        {
            IList<UserMessage> listedUserMessage = await _manager.UserMessageRepository.GetListAsync();
            List<ResultUserMessageDto> result = _mapper.Map<List<ResultUserMessageDto>>(listedUserMessage);

            return result;
        }

        public async Task<GetByIdUserMessageDto> GetByIdUserMessageAsync(int id)
        {
            UserMessage userMessage = await _manager.UserMessageRepository.GetAsync(x => x.Id.Equals(id));
            GetByIdUserMessageDto result = _mapper.Map<GetByIdUserMessageDto>(userMessage);

            return result;
        }

        public async Task<List<ResultInboxUserMessageDto>> GetInboxUserMessageAsync(string receiverId)
        {
            IList<UserMessage> listedUserMessage = await _manager.UserMessageRepository.GetListAsync(x => x.ReceiverId.Equals(receiverId));
            List<ResultInboxUserMessageDto> result = _mapper.Map<List<ResultInboxUserMessageDto>>(listedUserMessage);

            return result;
        }

        public async Task<List<ResultSendboxUserMessageDto>> GetSendboxUserMessageAsync(string senderId)
        {
            IList<UserMessage> listedUserMessage = await _manager.UserMessageRepository.GetListAsync(x => x.SenderId.Equals(senderId));
            List<ResultSendboxUserMessageDto> result = _mapper.Map<List<ResultSendboxUserMessageDto>>(listedUserMessage);

            return result;
        }

        public async Task UpdateUserMessageAsync(UpdateUserMessageDto updateUserMessageDto)
        {
            UserMessage getUserMessage = await _manager.UserMessageRepository.GetAsync(x => x.Id.Equals(updateUserMessageDto.Id));
            updateUserMessageDto.CreatedDate = getUserMessage.CreatedDate;
            UserMessage mappedUserMessage = _mapper.Map(updateUserMessageDto, getUserMessage);
            await _manager.UserMessageRepository.UpdateAsync(mappedUserMessage);

        }
    }
}
