import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'fetchdata',
    templateUrl: './fetchdata.component.html'
})
export class FetchDataComponent {
    public categories: Categories;

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {

        http.get(baseUrl + 'api/SampleData/GetCategories').subscribe(result => {
            //this.categories = result.json().response.data.categories as Category[];
            this.categories = result.json() as Categories;
            console.log(this.categories);

        }, error => console.error(error));
    }

}

interface Categories {
    "categories": Category;
}

interface Category {
    "category": Item[];
}

interface Item {
    "id": string;
    "name": string;
}
