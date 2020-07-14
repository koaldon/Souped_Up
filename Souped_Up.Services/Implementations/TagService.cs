using Souped_Up.Data;
using Souped_Up.Models;
using Souped_Up.Repos.Interfaces;
using Souped_Up.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Souped_Up.Services.Implementations
{
    public class TagService : ITagService
    {
        private ITagRepo tagRepo { get; set; }
        public TagService(ITagRepo tag)
        {
            tagRepo = tag;
        }
        //Create
        public bool Create(TagViewCreateModel model)
        {
            var tag = new Tag
            {
                UserId = model.UserId,
                Name = model.Name,
                Description = model.Description
            };
            tag = tagRepo.Create(tag);
            return tag.Id != 0;
        }
        //Read
        public Tag FindById(int id)
        {
            var tag = tagRepo.GetById(id);
            return tag;
        }
        public IEnumerable<TagViewListModel> GetUserTags(Guid id)
        {
            var tags = tagRepo.GetByUserId(id);

            var models = new List<TagViewListModel>();
            foreach (var tag in tags)
            {
                var model = new TagViewListModel()
                {
                    Id = tag.Id,
                    Name = tag.Name,
                    Description =tag.Description
                };
                models.Add(model);
            }
            return models;
        }
        public TagViewDetailModel GetDetails(int id)
        {
            var tag = tagRepo.GetById(id);
            var model = new TagViewDetailModel()
            {
                Id = tag.Id,
                Name = tag.Name,
                Description = tag.Description
            };
            return model;
        }

        //Update
        public bool Update(TagViewEditModel model)
        {
            var tag = tagRepo.GetById(model.Id);

            tag.Name = model.Name;
            tag.Description = model.Description;

            return tagRepo.Update(tag);

        }
        public TagViewEditModel GetEditById(int id)
        {
            var tag = tagRepo.GetById(id);
            var model = new TagViewEditModel
            {
                Name = tag.Name,
                Description = tag.Description
            };

            return model;
        }
        //Delete
        public bool Delete(int id)
        {

            return tagRepo.DeleteById(id);
        }

    }
}
