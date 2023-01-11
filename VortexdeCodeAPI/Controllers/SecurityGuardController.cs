using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VortexdeCodeAPI.Responses;
using VortexdeCodeAPI.Services;
using VortexdeCodeAPI.ViewModel;
using VortexdeCodeBL;
using VortexdeCodeDL.Entitys;
using VortexdeCodeDL.Models;

namespace VortexdeCodeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityGuardController : ControllerBase
    {
        private ISecurityGuardBL _ISecurityGuardBL;
        private readonly IEmailSender _sender;
        //_sender.SendEmailAsync("ciphertip@gmail.com","Test-email - Subject", "Test-email - Body");

        public SecurityGuardController(ISecurityGuardBL iSecurityGuardBL, IEmailSender sender)
        {
            _ISecurityGuardBL = iSecurityGuardBL;
            _sender = sender;
        }
        [HttpGet]
        [Route("GetFloors")]
        //[ApiExplorerSettings(IgnoreApi = true)]
        public FloorResponse GetFloors()
        {
            FloorResponse response = new FloorResponse();
            IEnumerable<Floor> floorList = _ISecurityGuardBL.getFloors();
            if (floorList != null)
            {
                response.Floors = (from floor in floorList
                                   where floor.Is_Actve == true
                                   select new floor { Id = floor.Id, Name = floor.Name }).AsEnumerable();
            }

            return response;
        }

        [HttpPost]
        [Route("GetQuestion")]
        public QuestionAnswerModel GetQuestion([FromBody] QuestionRequestModel request)
        {

            QuestionAnswerModel QuestionAnswerList = _ISecurityGuardBL.getQuestionAnswerById(request.FloorID);
           

            return QuestionAnswerList;
        }

        [HttpPost]
        [Route("SetAnswer")]
        public string SetAnswer([FromBody] InspectionReportViewModel request)
        {
            InspectionReport objModel = new InspectionReport();
            objModel.TimeSlotId = request.TimeSlotId;
            objModel.FloorId = request.FloorId;
            objModel.QuestionId = request.QuestionId;
            objModel.AnswerId = request.AnswerId;
            objModel.Notes = request.Notes;
            objModel.LogEntryTime = request.LogEntryTime;
            objModel.IsEdited = request.IsEdited;
            objModel.ReasonForEdit = request.ReasonForEdit;
            objModel.IsManualEntry = request.IsManualEntry;
            objModel.CreatedBy = request.CreatedBy;
            objModel.CreatedDate = request.CreatedDate;
            objModel.ModifiedBy = request.ModifiedBy;
            objModel.ModifiedDate = request.ModifiedDate;




            return _ISecurityGuardBL.SetInspection_Report(objModel);
            
        }


    }
}
