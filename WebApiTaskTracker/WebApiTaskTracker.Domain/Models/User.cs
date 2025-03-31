namespace WebApiTaskTracker.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; } 
        public string Login { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        private List<UserBoard> _userBoards;
        public ICollection<UserBoard> UserBoards => _userBoards;

        public User(string login, string passwordHash, string userName, string email, List<UserBoard>? userBoards = null)
        {
            Id = Guid.NewGuid();
            Login = login;
            PasswordHash = passwordHash;
            UserName = userName;
            Email = email;
            _userBoards = userBoards ?? new();
        }

        public User(Guid id,string login, string passwordHash, string userName, string email, List<UserBoard>? userBoards = null)
        {
            Id = id;
            Login = login;
            PasswordHash = passwordHash;
            UserName = userName;
            Email = email;
            _userBoards = userBoards ?? new();
        }

        public void AddBoard(Board board, string role)
        {

            if (_userBoards.Any(ub => ub.IdBoard == board.Id))
                throw new InvalidOperationException("Пользователь уже добавлен в эту доску");

            _userBoards.Add(new UserBoard(Id, board.Id, role));
        }
    }
}
