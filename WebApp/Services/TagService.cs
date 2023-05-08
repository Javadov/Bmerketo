using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Repositories;

namespace WebApp.Services;

public class TagService
{
    private readonly TagRepository _tagRepo;

    public TagService(TagRepository tagRepo)
    {
        _tagRepo = tagRepo;
    }

    public async Task<List<SelectListItem>> GetTagsAsync()
    {
        var tags = new List<SelectListItem>();

        foreach (var tag in await _tagRepo.GetAllAsync()) 
        { 
            tags.Add(new SelectListItem
            {
                Value = tag.Id.ToString(),
                Text = tag.Tag
            });
        }

        return tags;
    }

    public async Task<List<SelectListItem>> GetTagsAsync(string[] selectedTags)
    {
        var tags = new List<SelectListItem>();

        foreach (var tag in await _tagRepo.GetAllAsync())
        {
            tags.Add(new SelectListItem
            {
                Value = tag.Id.ToString(),
                Text = tag.Tag,
                Selected = selectedTags.Contains(tag.Id.ToString())
            });
        }

        return tags;
    }
}
