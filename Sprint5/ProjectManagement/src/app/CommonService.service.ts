import { HttpClient, HttpParams } from '@angular/common/http';
import { Inject } from '@angular/core';
import { Observable } from 'rxjs';

@Inject({
  providedIn: 'root'
})
export class CommonServiceService<T> {

  protected readonly apiUrl = `${this.baseUrl}/${this.entityname}`;
  constructor(
    protected readonly http: HttpClient,
    protected readonly entityname: string,
    protected readonly baseUrl: string="https://localhost:44303/api"
  ) {}


  create(body: T): Observable<T> {
    console.log(body);
    return this.http.post<T>(this.apiUrl, body);
  }

  getById(id: number): Observable<T> {
    const url = this.entityUrl(id);
    return this.http.get<T>(url);
  }

  getAll(): Observable<T[]> {
    return this.http.get<T[]>(this.apiUrl);
  }

  update(body: T): Observable<T> {
    return this.http.put<T>(this.apiUrl, body);
  }

  delete(id: number): Observable<T> {
    const url = this.apiUrl+'?id='+id;
    return this.http.delete<T>(url);
  }

  protected entityUrl(id: number): string {
    return [this.apiUrl, id].join('/');
  }
}
