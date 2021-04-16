using Anki.Vector.ExternalInterface;
using Anki.Vector.Types;
using System.Threading.Tasks;

namespace Anki.Vector
{
    /// <summary>
    /// Alexa Component
    /// </summary>
    public class AlexaComponent: Component
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="robot">Robot object</param>
        internal AlexaComponent(Robot robot) : base(robot)
        {
        }

        /// <summary>
        /// Calls RPC to authenticate the Amazon Alexa
        /// </summary>
        /// <returns></returns>
        public async Task<AlexaOptInResponse> AlexaLogin()
        {
            var response = await Robot.RunMethod(client => client.AlexaOptInAsync(new AlexaOptInRequest() { OptIn = true })).ConfigureAwait(false);
            response.Status.EnsureSuccess();
            return new AlexaOptInResponse(response);
        }

        /// <summary>
        /// Calls RPC to log out the Amazon Alexa
        /// </summary>
        /// <returns></returns>
        public async Task<AlexaOptInResponse> AlexaLogout()
        {
            var response = await Robot.RunMethod(client => client.AlexaOptInAsync(new AlexaOptInRequest() { OptIn = false })).ConfigureAwait(false);
            response.Status.EnsureSuccess();
            return new AlexaOptInResponse(response);
        }


        /// <summary>
        /// Reads the state of Amazon Alexa authentication
        /// </summary>
        /// <returns></returns>
        public async Task<AlexaAuthStatus> ReadAlexaAuthState()
        {
            var response = await Robot.RunMethod(client => client.GetAlexaAuthStateAsync(new AlexaAuthStateRequest())).ConfigureAwait(false);
            response.Status.EnsureSuccess();
            return new AlexaAuthStatus(response);
        }

        internal override Task Teardown(bool forced)
        {
            return Task.CompletedTask;
        }
    }
}