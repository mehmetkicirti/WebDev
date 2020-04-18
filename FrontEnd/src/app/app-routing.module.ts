import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BookComponent } from './components/book/book.component';
import { AuthorComponent } from './components/author/author.component';

//sitede urlde books yazınca bookcomponentini acıcak
const routes: Routes = [
  {path: "books",component:BookComponent},
  {path: "authors",component:AuthorComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
