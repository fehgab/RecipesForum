﻿using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebPPublished.DTO;
using WebPPublished.Models;

namespace WebPPublished.Manager
{
    public class CommentManager
    {
        public IPagedList<CommentHeaderData> GetRecipeComments(int RecipeId, int pageNumber)
        {
            using (var context = new ApplicationDbContext())
            {
                var RecipeComments = context.Comments
                    .Where(p => p.Recipes.ID == RecipeId)
                    .OrderByDescending(c => c.CreatedDate)
                    .Select(Comments.SelectHeader)
                    .ToPagedList(pageNumber, 8);
                return RecipeComments;
            }
        }

        public List<Comments> GetRecipeCommentsList(int RecipeId)
        {
            using (var context = new ApplicationDbContext())
            {
                var RecipeComments = context.Comments
                    .Where(p => p.Recipes.ID == RecipeId).ToList();
                return RecipeComments;
            }
        }

        public Comments GetCommentHeaderData(int commentId)
        {
            using (var context = new ApplicationDbContext())
            {
                var Comment = context.Comments
                    .Where(p => p.Id == commentId).First();
                return Comment;
            }
        }
    }
}