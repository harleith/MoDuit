using Microsoft.AspNetCore.Mvc;
using MoDuit.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MoDuit.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoDuitController : Controller
    {
        [HttpGet("/backend/question/one")]
        public JsonResult One()
        {

            List<QuestionModel.QuestionOne> qOne = new List<QuestionModel.QuestionOne>();
            string jsonFilePath = @"D:\Codingan test\Test Glints\MoDuit\Data\QuestionOne.json";

            using (StreamReader r = new StreamReader(jsonFilePath))
            {
                string json = r.ReadToEnd();
                qOne = JsonConvert.DeserializeObject<List<QuestionModel.QuestionOne>>(json);
            }

            Random rndm = new Random();
            var randomIndex = rndm.Next(0, qOne.Count());


            return new JsonResult(qOne[randomIndex]);
        }

        [HttpGet("/backend/question/two")]
        public JsonResult Two()
        {
            List<QuestionModel.QuestionTwo> qTwo = new List<QuestionModel.QuestionTwo>();
            string jsonFilePath = @"D:\Codingan test\Test Glints\MoDuit\Data\QuestionTwo.json";

            using (StreamReader r = new StreamReader(jsonFilePath))
            {
                string json = r.ReadToEnd();
                qTwo = JsonConvert.DeserializeObject<List<QuestionModel.QuestionTwo>>(json);
            }

            var questionTwo = qTwo.Where(x => x.description.Contains("Ergonomics") || x.title.Contains("Title") && x.tags.Contains("Sports")).OrderByDescending(y => y.id).TakeLast(3);

            return new JsonResult(questionTwo);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        /// {
        /// "id": 800728,
        ///"category": 4,
        /// "items": [
        ///  {
        ///    "title": "Incredible Steel Salad",
        ///    "description": "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit",
        ///    "footer": "Incredible"
        /// },
        ///  {
        ///   "title": "Practical Frozen Ball",
        ///    "description": "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J",
        ///    "footer": "Ergonomic"
        ///  },
        ///    {
        ///  "title": "Sleek Cotton Pants",
        ///      "description": "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit",
        ///      "footer": "Handmade"
        ///  }
        /// ],
        ///  "createdAt": "2021-06-28T10:59:47.2135292+00:00"
        ///   }
        ///
        /// </remarks> 
        [HttpPost("/backend/question/three")]
        public IActionResult Three(QuestionModel.QuestionThree model)
        {
            List<QuestionModel.AnswerQuestionThree> answer = new List<QuestionModel.AnswerQuestionThree>();

            foreach (var item in model.items)
            {
                answer.Add(new QuestionModel.AnswerQuestionThree
                {
                    id = model.id,
                    category = model.category,
                    title = item.title,
                    description = item.description,
                    footer = item.footer,
                    createdAt = model.createdAt
                });
            }

            return new JsonResult(answer);
        }

    }
}
