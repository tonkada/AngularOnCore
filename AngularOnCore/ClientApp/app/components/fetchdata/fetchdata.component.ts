import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'fetchdata',
    templateUrl: './fetchdata.component.html'
})
export class FetchDataComponent {
    public categories: Category[];
    public json: string;

    constructor(http: Http) {
        http.get('http://thecatapi.com/' + 'api/categories/list').subscribe(result => {
            //this.categories = result.json().response.data.categories as Category[];
            this.json = JSON.stringify(result);
        }, error => console.error(error));
    }
}

interface Category {
    id: number;
    name: string;
}
