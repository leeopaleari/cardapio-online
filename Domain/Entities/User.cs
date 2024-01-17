using CardapioOnline.Domain.Validations;

namespace CardapioOnline.Domain.Entities;

public class User
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }

    public User(string id, string firstName, string lastName, DateTime birthDate, string email, string phone)
    {
        DomainExceptionValidation.When(Id.Length == 0, "O campo é obrigatório");

        Id = id;
        ValidateDomain(firstName, lastName, birthDate, email, phone);
    }

    public User(string firstName, string lastName, DateTime birthDate, string email, string phone)
    {
        ValidateDomain(firstName, lastName, birthDate, email, phone);
    }

    public void UpdatePassword(byte[] passwordHash, byte[] passwordSalt)
    {
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
    }

    private void ValidateDomain(string firstName, string lastName, DateTime birthDate, string email, string phone)
    {
        
        DomainExceptionValidation.When(BirthDate == null, "O campo Data Nascimento não pode ser nulo");
        
        DomainExceptionValidation.When(FirstName == null, "O campo Nome não pode ser nulo");
        DomainExceptionValidation.When(FirstName.Length > 15, "O campo Nome não pode ultrapassar 15 caracteres.");
        
        DomainExceptionValidation.When(LastName == null, "O campo Sobrenome não pode ser nulo");
        DomainExceptionValidation.When(LastName.Length > 50, "O campo Sobrenome não pode ultrapassar 50 caracteres.");
        
        DomainExceptionValidation.When(Email.Length > 60, "O campo Email não pode ultrapassar 60 caracteres.");
        DomainExceptionValidation.When(Email.Length > 60, "O campo Email não pode ultrapassar 60 caracteres.");
        
        DomainExceptionValidation.When(Phone.Length > 11, "O campo Telefone não pode ultrapassar 11 caracteres.");
        
        
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
        Email = email;
        Phone = phone;
        
    }
}