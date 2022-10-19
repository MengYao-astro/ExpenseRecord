import { Injectable } from '@angular/core';
import { Observable, of, throwError } from 'rxjs';
import { ExpenseItem } from '../models/ExpenseItem';
import { HttpClient } from '@angular/common/http';
import { catchError, retry } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
  })
  export class ExpenseService {
    httpAddress : string = "https://localhost:44425/expense";
    /**
     *
     */
    constructor(private http: HttpClient) {
    }
  
    getAll(): Observable<ExpenseItem[]> {
      return this.http.get<ExpenseItem[]>(this.httpAddress)
    }
  
    
    getOne(id: string): Observable<ExpenseItem | never> {
      return this.http.get<ExpenseItem>(this.httpAddress + "/" +id)   
    }
  
    createOne(body: ExpenseItem): Observable<any> {
      return this.http.post<any>(this.httpAddress,body);
    }
  
    updateOne(id: string, body: ExpenseItem): Observable<ExpenseItem> {
      return this.http.put<ExpenseItem>(this.httpAddress + "/" + body.id, body)
    }
  
    deleteOne(id: string): Observable<void> {
      return this.http.delete<any>(this.httpAddress + "/" + id)
    }
  }
  