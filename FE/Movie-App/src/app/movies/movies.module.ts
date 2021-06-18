import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { MoviesComponent } from './movies.component';
import { MoviesRepositoryService } from './services/movies-repository.service';
import { FilterPipe } from './pipes/filter.pipe';
import { MovieDetailComponent } from '../movie-detail/movie-detail.component';
import { CommonModule } from '@angular/common';

@NgModule({
  imports: [
    HttpClientModule,
    CommonModule,
    RouterModule.forChild([
      { path: 'movies', component: MoviesComponent },
      { path: 'movies/:id', component: MovieDetailComponent }
    ]),
    FormsModule
   ],
  declarations: [
    MoviesComponent,
    FilterPipe
    
  ],
  exports: [ ],
  providers: [
    HttpClientModule,
    MoviesRepositoryService
  ]
})
export class MoviesModule { }
