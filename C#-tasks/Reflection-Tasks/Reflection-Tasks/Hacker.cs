namespace Reflection_Tasks;

public class Hacker
{
    public string username = "securityGod82";
    private string password = "mySuperSecretPassw0rd";
    public string Password { get=>this.password; set => password = value; }
    private int ID { get; set; }
    public double BankAccountBalance { get; private set; }

    public void DownloadAllBankAccountsInTheWorld()
    {

    }
}