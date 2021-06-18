import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { MoviesRepositoryService } from '../movies/services/movies-repository.service';
import { Movie } from '../movies/models/movie.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-movie-detail',
  templateUrl: './movie-detail.component.html',
  styleUrls: ['./movie-detail.component.scss']
})
export class MovieDetailComponent implements OnInit {
  movie: Movie = null;
  error: string = null;

  constructor(
    private moviesRepositoryService: MoviesRepositoryService,
    private activatedRoute: ActivatedRoute,private router: Router) { }

  ngOnInit() {
    const { id } = this.activatedRoute.snapshot.params;
    this.getMovie(id);
  }

  getMovie(id: number) {
    this.moviesRepositoryService.getMovies()
      .subscribe(data => {
        this.movie = data.movies.find(x => x.id == id),
        console.log(this.movie)
      },
        err => this.error = err,
      );
  }

  goToMainPage(pageName:string){
    this.router.navigate(['']);
  }
}
