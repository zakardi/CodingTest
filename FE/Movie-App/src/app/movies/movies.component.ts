import { Component, OnInit } from '@angular/core';
import { Movie } from './models/movie.model';
import { MoviesRepositoryService } from './services/movies-repository.service';

@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.scss']
})
export class MoviesComponent implements OnInit {

  movies: Movie[];
  visibleMovies: Movie[] = null;

  searchText: any = '';

  location: any = 'all';

  constructor(
    private moviesRepositoryService: MoviesRepositoryService) {
  }

  ngOnInit() {
    this.moviesRepositoryService.getMovies()
      .subscribe(movies => {
        this.movies = movies.movies;
        this.visibleMovies = this.movies;
        console.log(this.movies)
      });
  }



  public filterBylocation() {
    if (this.location == "all") {
      return this.visibleMovies = this.movies;
    }
    else {
      this.visibleMovies = this.movies.filter(c => c.location.toLowerCase() == this.location.toLowerCase());
    }
  }
}
