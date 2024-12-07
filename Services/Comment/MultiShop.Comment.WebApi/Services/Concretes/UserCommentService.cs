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
            _manager.UserComment.Add(userComment);
        }

        public void DeleteUserComment(int id)
        {
            GetByIdUserCommentDto userComment = GetUserCommentById(id);
            UserComment result = _mapper.Map<UserComment>(userComment);

            if (result is not null)
            {
                _manager.UserComment.Delete(result);
            }
        }

        public IEnumerable<ResultUserCommentDto> GetAllUserComments()
        {
            IList<UserComment> userComments = _manager.UserComment.GetList();
            IEnumerable<ResultUserCommentDto> result = _mapper.Map<IEnumerable<ResultUserCommentDto>>(userComments);

            return result;
        }

        public GetByIdUserCommentDto GetUserCommentById(int id)
        {
            UserComment? userComment = _manager.UserComment.Get(x => x.Id.Equals(id));
            GetByIdUserCommentDto result = _mapper.Map<GetByIdUserCommentDto>(userComment);

            return result;
        }

        public IEnumerable<ResultUserCommentDto> GetyUserCommentByProductId(string id)
        {
            IList<UserComment> userComment = _manager.UserComment.GetList(predicate: x => x.ProductId.Equals(id));
            IEnumerable<ResultUserCommentDto> result = _mapper.Map<IEnumerable<ResultUserCommentDto>>(userComment);

            return result;
        }

        public void UpdateUserComment(UpdateUserCommentDto updateUserCommentDto)
        {
            UserComment userComment = _mapper.Map<UserComment>(updateUserCommentDto);
            _manager.UserComment.Update(userComment);
        }
    }
}
