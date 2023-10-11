import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Employee } from "./interface/employee";

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html',
  styleUrls: ['./fetch-data.component.css']
})
export class FetchDataComponent implements OnInit {
  data!: Employee[];
  selectedItem!: Employee | null;
  newItemForm!: FormGroup;
  selectedItemForm!: FormGroup;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private fb: FormBuilder) {}

  ngOnInit() {
    this.loadData();
    this.initForm();
  }

  loadData() {
    this.http.get<any[]>(this.baseUrl + 'employee/getAll')
      .subscribe(data => {
        this.data = data;
      });
  }

  initForm() {
    this.selectedItemForm = this.fb.group({
      id: ['', Validators.required],
      lastName: ['', Validators.required],
      firstName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
    });
    this.newItemForm = this.fb.group({
      newLastName: ['', Validators.required],
      newFirstName: ['', Validators.required],
      newEmail: ['', [Validators.required, Validators.email]]
    });
  }

  editItem(item: any) {
    this.selectedItem = item;

    this.selectedItemForm.patchValue({
      id: item.id,
      lastName: item.lastName,
      firstName: item.firstName,
      email: item.email
    });
  }

  saveItem() {
    debugger
    let updatedItem = this.selectedItemForm.value;

    this.http.put(this.baseUrl + 'employee/update', this.selectedItemForm.value)
      .subscribe(() => {
        this.selectedItem = null;
        this.loadData();
      });

  }

  cancelEdit() {
    this.selectedItem = null;
  }

  deleteItem(item: any) {
    this.http.delete(this.baseUrl + 'employee/delete/' + item.id)
      .subscribe(() => {
        this.data = this.data.filter(i => i.id !== item.id);
        this.loadData();
      });
  }

  addItem() {
    if (this.newItemForm.valid) {
      const newItem = {
        id: 0,
        lastName: this.newItemForm.get('newLastName')?.value,
        firstName: this.newItemForm.get('newFirstName')?.value,
        email: this.newItemForm.get('newEmail')?.value,
      };

      this.http.post(this.baseUrl + 'employee/add', newItem)
        .subscribe((response: any) => {
          newItem.id = response.id;
          this.data.push(newItem);
          this.newItemForm.reset();
          this.loadData();
        });
    }
  }
}
