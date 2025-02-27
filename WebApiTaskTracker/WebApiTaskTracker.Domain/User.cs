namespace WebApiTaskTracker.Domain
{
    public class User(int Id, string Login, string Password, string UserName, string Email)
    {
        public int Id { get; set; }
        public string Login { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;


        private readonly List<UserBoard> _userBoards = new();
        public IReadOnlyCollection<UserBoard> UserBoards => _userBoards.AsReadOnly();

        public void AddBoard(Board board, string role)
        {

            if (_userBoards.Any(ub => ub.IdBoard == board.Id))
                throw new InvalidOperationException("Пользователь уже добавлен в эту доску");

            _userBoards.Add(new UserBoard(Id, board.Id, role));
        }
    }
}
