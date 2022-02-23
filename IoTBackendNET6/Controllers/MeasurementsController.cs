using Microsoft.AspNetCore.Mvc;
using IoTBackendNET6.Models;

namespace IoTBackendNET6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementsController : ControllerBase
    {

        private static readonly iotdataContext db = new iotdataContext();


        // Hae kaikki mittaukset
        [HttpGet]
        [Route("")]
        public ActionResult GetAll()
        {
            List<Measurement> measurements = db.Measurements.ToList();
            return Ok(measurements);
        }

        // Anna komento talletettavaksi staattiseen luokkamuuttujaan
        [HttpPost]
        [Route("command")]
        public ActionResult GiveCommand(string c)
        {
            Command.Cmd = c;
            return Ok("Tallennettu komento" + c);
        }

        // Lue komento staattisesta luokkamuuttujasta
        [HttpGet]
        [Route("command")]
        public ActionResult GetCommand()
        {
            string command = Command.Cmd;
            if (string.IsNullOrEmpty(command)) {
                return Ok("No command this time");
            }
            else {
                Command.Cmd = null;
                return Ok(command);
            }
        }


        [HttpPost]
        [Route("")]
        public ActionResult CreateMeasurement([FromBody] Measurement mittaus)
        {
            try
            {
                mittaus.Time = DateTime.Now.AddHours(2); // Aikaleima laitetaan back-endissä, muut tulee IoT laitteesta
                //Päivitys: Lisätty 2h koska palvelinkone on Irlannissa.

                db.Measurements.Add(mittaus);
                db.SaveChanges();
                return Ok("Kiitos! Tallennettu id:llä " + mittaus.MeasurementId);
            }
            catch (Exception e)
            {
                return BadRequest("Jotain meni pieleen, mutta pyyntö tuli perille. Kts: " + e.GetType().Name + " : " + e.Message);
            }
           
        }
    }
}
