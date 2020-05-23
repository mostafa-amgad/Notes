using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Amazon.Extensions.CognitoAuthentication;
using Amazon.Runtime;

namespace Notes.Classes
{
    public class Authentication
    {
        const string appClientId = "1pe4jp1nmsqb19ta0sf4sgrjt5";
        const string poolId = "us-east-1_DNd1jIHmH";
        static RegionEndpoint region = RegionEndpoint.USEast1;

        public static async Task SignUp(string email, string username, string password)
        {
            AmazonCognitoIdentityProviderClient providerClient = new AmazonCognitoIdentityProviderClient(new AnonymousAWSCredentials()
                , region);

            //Signing Up..
            SignUpRequest signUpRequest = new SignUpRequest()
            {
                ClientId = appClientId,
                Username = username,
                Password = password
            };

            List<AttributeType> attributes = new List<AttributeType>()
            {
                new AttributeType(){Name="email", Value = email}
            };

            signUpRequest.UserAttributes = attributes;

            try
            {
                SignUpResponse response = await providerClient.SignUpAsync(signUpRequest);
                Debug.WriteLine("SUCC");
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                Debug.WriteLine("Erorr Sign Up" + e.Message);
                return;
            }
        }

        public static async Task SignIn(string username, string password)
        {
            AmazonCognitoIdentityProviderClient providerClient = new AmazonCognitoIdentityProviderClient(new AnonymousAWSCredentials()
                , region);

            CognitoUserPool userPool = new CognitoUserPool(poolId, appClientId, providerClient);
            CognitoUser cognitoUser = new CognitoUser(username, appClientId, userPool, providerClient);

            InitiateSrpAuthRequest authRequest = new InitiateSrpAuthRequest()
            {
                Password = password
            };

            try
            {
                AuthFlowResponse authFlow = await cognitoUser.StartWithSrpAuthAsync(authRequest).ConfigureAwait(false);
                Debug.WriteLine("SUCC");
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return;
            }
        }
    }
}
