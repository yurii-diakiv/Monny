import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Expense } from 'src/app/models/expense';

@Injectable()
export class ExpenseService {

  constructor(private http: HttpClient) { }

  add(expense: Expense) {
    return this.http.post<Expense>("https://localhost:5001/expenses", expense);
  }

  getExpensesForThisMonth(userId: number) {
    return this.http.get<Expense[]>("https://localhost:5001/expenses/forThisMonth/"+userId);
  }

  getFromTo(userId: number, from: Date, to: Date) {
    return this.http.get<any[]>(
      `https://localhost:5001/expenses/fromTo?userId=${userId}&from=${from.toISOString()}&to=${to.toISOString()}`);
  }
}
