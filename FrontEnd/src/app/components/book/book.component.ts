import { Component, OnInit } from '@angular/core';
import { Book } from 'src/app/models/book';
import { BookService } from 'src/app/services/book.service';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',//buradaki datalardan besleniyor.
  styleUrls: ['./book.component.css']
})
export class BookComponent implements OnInit {

  //burada dependency injection calısıyor..
  constructor(private bookService:BookService) { }
  books: Book[];
  ngOnInit(): void {
    //component acıldıgında calısır 
    this.getBooks();//bu kodu gerceklestir diyoruz.
  }
  getBooks(){
    //get books operasyonu icin abone ol observable oldugu icin data dönücek süslü parantezdeki kodu gerceklestir 
    this.bookService.getBooks().subscribe(data=>{
      this.books = data;
    });
  }

}
