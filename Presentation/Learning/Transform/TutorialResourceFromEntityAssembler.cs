using Domain.Learning.Model.Entities;
using Presentation.Learning.Resources;

namespace Presentation.Learning.Transform;

public static class TutorialResourceFromEntityAssembler
{
    /// <summary>
    /// Assembles a FavoriteSourceResource from a FavoriteSource. 
    /// </summary>
    /// <param name="entity">The FavoriteSource entity</param>
    /// <returns>
    /// A FavoriteSourceResource assembled from the FavoriteSource
    /// </returns>
    public static TutorialResource ToResourceFromEntity(Tutorial entity) =>
        new TutorialResource(entity.Id, entity.Title, entity.Summary);
}