import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Book } from '../models/book';

@Injectable({
  providedIn: 'root'
})
export class BookService {
  path = "https://localhost:44308/api/books/getall";
  constructor(private httpClient:HttpClient) { 
    //gelmedi app module e tanımlanmıs olmalı cünkü modul httpclient
  }
  //observable book nesnesi döndür diyoruz
  getBooks():Observable<Book[]>{
    //get istegini book arrayine ata yolunda path
    return this.httpClient.get<Book[]>(this.path);
  }
}
