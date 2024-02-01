using Azure.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using Send_Mail_Using_Microsoft_Graph.Models;

namespace Send_Mail_Using_Microsoft_Graph.Application.Microsoft.Graph.Mail
{
    public interface IMsGraphMailAppService
    {
        Task SendAsync(GraphMail mail);
    }

    public class MsGraphMailAppService : IMsGraphMailAppService
    {
        private readonly IConfiguration _configuration;

        public MsGraphMailAppService(
            IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendAsync(GraphMail mail)
        {
            // Set Azure credentials from User Secrets
            string clientSecret = _configuration["clientSecret"];
            string clientId = _configuration["clientId"];
            string tenantId = _configuration["tenantId"];

            ClientSecretCredential azureCredentials = new(tenantId, clientId, clientSecret); // Azure Credentials from User Secrets
            GraphServiceClient msGraphClient = new(azureCredentials); // Token Credentials for MS Graph API

            // Construct the message object
            Message message = new()
            {
                // Set sender
                ToRecipients = new List<Recipient>()
                {
                    new Recipient
                    {
                        EmailAddress = new EmailAddress
                        {
                            Address = mail.ToEmail
                        }
                    }
                },

                // Set subject and message
                Subject = mail.Subject,
                Body = new ItemBody
                {
                    ContentType = mail.ContentType,
                    Content = mail.Content
                }
            };

            await msGraphClient.Users[mail.FromEmail]
                .SendMail(message, mail.SaveToSentItems)
                .Request()
                .PostAsync();
        }
    }
}

