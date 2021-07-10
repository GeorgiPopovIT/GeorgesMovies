using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Html.Dom;
using GeorgesMovies.Services.Models;

namespace GeorgesMovies.Services.Scraper
{
    public class MovieScraperService : IMovieScraperService
    {
        private readonly IConfiguration config;
        private readonly IBrowsingContext context;
        public MovieScraperService()
        {
            this.config = Configuration.Default.WithDefaultLoader();
            this.context = BrowsingContext.New(config);
        }
        public void PopulateDbWithMovies()
        {
            //Parallel.For(12528166, 17000000, (i) =>
            //  {
            //      GetMovies(i);
            //  });
        }
        private MovieDto GetMovies(int id)
        {
            var document = context.OpenAsync($"https://www.imdb.com/title/tt{id}/?ref_=rlm")
                .GetAwaiter()
                .GetResult();
            //Get titles
            if (document.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                Console.WriteLine("Not Found");
                return null;
            }
            var movieDto = new MovieDto();
            var titles = document
                .QuerySelector("#__next > main > div > section.ipc-page-background.ipc-page-background--base.TitlePage__StyledPageBackground-wzlr49-0.dDUGgO > section > div:nth-child(4) > section > section > div.TitleBlock__Container-sc-1nlhx7j-0.hglRHk > div.TitleBlock__TitleContainer-sc-1nlhx7j-1.jxsVNt > h1");
            movieDto.Title = titles.TextContent;
            //Get years
            var years = document
                .QuerySelector("#__next > main > div > section.ipc-page-background.ipc-page-background--base.TitlePage__StyledPageBackground-wzlr49-0.dDUGgO > section > div:nth-child(4) > section > section > div.TitleBlock__Container-sc-1nlhx7j-0.hglRHk > div.TitleBlock__TitleContainer-sc-1nlhx7j-1.jxsVNt > div.TitleBlock__TitleMetaDataContainer-sc-1nlhx7j-2.hWHMKr > ul > li:nth-child(1) > span");
            movieDto.Year = int.Parse(years.TextContent);
            //Get time - string
            var times = document
                .QuerySelector("#__next > main > div > section.ipc-page-background.ipc-page-background--base.TitlePage__StyledPageBackground-wzlr49-0.dDUGgO > section > div:nth-child(4) > section > section > div.TitleBlock__Container-sc-1nlhx7j-0.hglRHk > div.TitleBlock__TitleContainer-sc-1nlhx7j-1.jxsVNt > div.TitleBlock__TitleMetaDataContainer-sc-1nlhx7j-2.hWHMKr > ul > li:nth-child(2)");
            movieDto.Time = times.TextContent;
            // Get Overview
            var overviews = document
                .QuerySelector("#__next > main > div > section.ipc-page-background.ipc-page-background--base.TitlePage__StyledPageBackground-wzlr49-0.dDUGgO > div > section > div > div.TitleMainBelowTheFoldGroup__TitleMainPrimaryGroup-sc-1vpywau-1.btXiqv.ipc-page-grid__item.ipc-page-grid__item--span-2 > section:nth-child(30) > div.Storyline__StorylineWrapper-sc-1b58ttw-0.iywpty > div.ipc-overflowText.ipc-overflowText--pageSection.ipc-overflowText--height-long.ipc-overflowText--long.ipc-overflowText--base > div.ipc-html-content.ipc-html-content--base > div");
            movieDto.Overview = overviews.TextContent;


            //Get relDates
            var relDates = document
                .QuerySelector("section:nth-child(42) > div.styles__MetaDataContainer-sc-12uhu9s-0.cgqHBf > ul > li:nth-child(1) > div > ul > li > a");
            movieDto.DateRealease = relDates.TextContent;

            //Get Countries of origin
            var countries = document
                .QuerySelector("section:nth-child(42) > div.styles__MetaDataContainer-sc-12uhu9s-0.cgqHBf > ul > li:nth-child(2) > div > ul > li > a");
            movieDto.CountryRealease = countries.TextContent;


            //Get ratings
            var ratings = document
                .QuerySelector("section > div:nth-child(4) > section > section > div.Hero__MediaContentContainer__Video-kvkd64-2.kmTkgc > div.Hero__ContentContainer-kvkd64-10.eaUohq > div.Hero__MetaContainer__Video-kvkd64-4.kNqsIK > div.RatingBar__RatingContainer-sc-85l9wd-0.hNqCJh.Hero__HideableRatingBar-kvkd64-12.hBqmiS > div > div:nth-child(1) > a > div > div > div.AggregateRatingButton__ContentWrap-sc-1ll29m0-0.hmJkIS > div.AggregateRatingButton__Rating-sc-1ll29m0-2.bmbYRW > span.AggregateRatingButton__RatingScore-sc-1ll29m0-1.iTLWoV");
            movieDto.Rating = decimal.Parse(ratings.TextContent);


            //Get PictureUrls
            var pictureUrl = document.QuerySelector("#__next > main > div > section.ipc-page-background.ipc-page-background--base.TitlePage__StyledPageBackground-wzlr49-0.dDUGgO > div > section > div > div.TitleMainBelowTheFoldGroup__TitleMainPrimaryGroup-sc-1vpywau-1.btXiqv.ipc-page-grid__item.ipc-page-grid__item--span-2 > section:nth-child(58) > div.AnswersCTA__AnswersCtaSection-sc-1ebj0gg-1.fajPuA > div > div.AnswersCTA__PosterSection-sc-1ebj0gg-2.jOLSip > div > img");
            movieDto.PictureUrl = pictureUrl.GetAttribute("src");

            //Get Genres

            var genresDoc = document
                .QuerySelectorAll("#__next > main > div > section.ipc-page-background.ipc-page-background--base.TitlePage__StyledPageBackground-wzlr49-0.dDUGgO > div > section > div > div.TitleMainBelowTheFoldGroup__TitleMainPrimaryGroup-sc-1vpywau-1.btXiqv.ipc-page-grid__item.ipc-page-grid__item--span-2 > section:nth-child(30) > div.Storyline__StorylineWrapper-sc-1b58ttw-0.iywpty > ul.ipc-metadata-list.ipc-metadata-list--dividers-all.Storyline__StorylineMetaDataList-sc-1b58ttw-1.esngIX.ipc-metadata-list--base > li:nth-child(1) > div > ul > li");
            foreach (var item in genresDoc)
            {
                movieDto.Genres.Add(item.TextContent);
            }

            //Get Actors

            var actoesDoc = document.QuerySelectorAll("#__next > main > div > section.ipc-page-background.ipc-page-background--base.TitlePage__StyledPageBackground-wzlr49-0.dDUGgO > section > div:nth-child(4) > section > section > div.Hero__MediaContentContainer__Video-kvkd64-2.kmTkgc > div.Hero__ContentContainer-kvkd64-10.eaUohq > div.Hero__MetaContainer__Video-kvkd64-4.kNqsIK > div.PrincipalCredits__ExpandablePrincipalCreditsPanelNarrowScreen-hdn81t-2.hbUbKF > div > div > ul > li.ipc-metadata-list__item.ipc-metadata-list-item--link > div > ul > li");
            foreach (var item in actoesDoc)
            {

               // movieDto.Actors.Add(ite)
            }
            //Get director
            var director = document.QuerySelector("#__next > main > div > section.ipc-page-background.ipc-page-background--base.TitlePage__StyledPageBackground-wzlr49-0.dDUGgO > section > div:nth-child(4) > section > section > div.Hero__MediaContentContainer__Video-kvkd64-2.kmTkgc > div.Hero__ContentContainer-kvkd64-10.eaUohq > div.Hero__MetaContainer__Video-kvkd64-4.kNqsIK > div.PrincipalCredits__ExpandablePrincipalCreditsPanelNarrowScreen-hdn81t-2.hbUbKF > div > div > ul > li:nth-child(1) > div > ul > li > a");

            
            Console.WriteLine($"{id}: Found!");
            return movieDto;
        }
    }
}
