using System.Threading.Tasks;
using DicomSync.Models;

namespace DicomSync.Controllers;

public class AetController
{
    public async Task<bool> EchoAsync(AetEndpoint endpoint)
    {
        // TODO: plug in real C-ECHO later
        await Task.Delay(200);
        return true;
    }
}
