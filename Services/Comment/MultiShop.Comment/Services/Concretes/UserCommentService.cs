using AutoMapper;
using MultiShop.Comment.Dtos.UserCommentDtos;
using MultiShop.Comment.Entities;
using MultiShop.Comment.Repositories.Abstracts;
using MultiShop.Comment.Services.Abstracts;

namespace MultiShop.Comment.Services.Concretes
{
    public class UserCommentService : IUserCommentService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public UserCommentService(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public void CreateUserComment(CreateUserCommentDto createUserCommentDto)
        {
            UserComment userComment = _mapper.Map<UserComment>(createUserCommentDto);
            _manager.UserComment.Create(userComment);
            _manager.Save();
        }

        public void DeleteUserComment(int id)
        {
            GetByIdUserCommentDto userComment = GetUserCommentById(id);
            UserComment result = _mapper.Map<UserComment>(userComment);

            if (result is not null)
            {
                _manager.UserComment.Delete(result);
                _manager.Save();
            }
        }

        public IEnumerable<ResultUserCommentDto> GetAllUserComments()
        {
            IQueryable<UserComment> userComment = _manager.UserComment.FindAll();
            IEnumerable<ResultUserCommentDto> result = _mapper.Map<IEnumerable<ResultUserCommentDto>>(userComment);

            return result;
        }

        public GetByIdUserCommentDto GetUserCommentById(int id)
        {
            UserComment? userComment = _manager.UserComment.FindByCondition(x => x.Id.Equals(id));
            GetByIdUserCommentDto result = _mapper.Map<GetByIdUserCommentDto>(userComment);

            return result;
        }

        public IEnumerable<ResultUserCommentDto> GetyUserCommentByProductId(string id)
        {
            IQueryable<UserComment> userComment = _manager.UserComment.FindAll(x => x.ProductId.Equals(id));
            IEnumerable<ResultUserCommentDto> result = _mapper.Map<IEnumerable<ResultUserCommentDto>>(userComment);

            return result;
        }

        public void UpdateUserComment(UpdateUserCommentDto updateUserCommentDto)
        {
            UserComment userComment = _mapper.Map<UserComment>(updateUserCommentDto);
            _manager.UserComment.Update(userComment);
            _manager.Save();
        }
    }
}
