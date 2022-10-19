import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ExpenseItem } from '../models/ExpenseItem';
import { ExpenseService } from '../services/ExpenseService';
import { isEmpty } from 'rxjs';

@Component({
  selector: 'app-expense-list',
  templateUrl: './expense-list.component.html',
  styleUrls: ['./expense-list.component.css']
})
export class ExpenseListComponent implements OnInit {
  public expenseList: Array<ExpenseItem> = new Array<ExpenseItem>;
  public newItem = {} as ExpenseItem;
  public form : FormGroup;

  constructor(private expenseService: ExpenseService, private router: Router, private route: ActivatedRoute, private fb: FormBuilder) { 
    this.form = this.fb.group({
      description: this.fb.control('', [Validators.required]),
      done: this.fb.control(''),
      favorite: this.fb.control('')
    });
    
  }

  ngOnInit(): void {
    
  }
  ngOnDestroy() {

  }


  private loadData(): void {
    this.expenseService.getAll().subscribe({
      next: todos => {
        this.expenseList = todos;
      }
      });
  }

  createItem(): void {
        this.expenseService.createOne(this.newItem).subscribe(id => {
          console.log(id);
      }, () => {
        console.error('Failed to create item');
      });
  }

  delete(item: ExpenseItem): void{
    const ok = confirm(`Delete this item?`)
    this.expenseService.deleteOne(item.id).subscribe(()=>{
      console.log("item deleted");
    }
    )
  }
}

