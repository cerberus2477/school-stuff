## Laravel unit tesztek jegyzet

tesztek egy része arról szólna, hogy a bejelentkezett felhasználó látja-e, ez most nálam nem lesz mert nincs login
- régi node.js van úgyhogy nem is lenne egyszerű  a login a sulis gépeken
- otthon / videóban jó lenne gyakorolni tho

- kellenek migrationsok hogy működjenek a tesztek
-
==***A Game projektbe nem tudtam teszteket rakni, mert elvileg kellenek hozzá migartionok. (ott sql-ből készül az adatbázis)***==
### phpunit.xml
- létezzen
- ne legyen kikommentelve az a két sor

### MakerControllerTest
`php artisan make:test MakerControllerTest`
	 - végén ott kell legyen hogy test
	 - `--unit` unit nélkül csináltuk végül, így a unit helyett a feature mappába megy
	 
- metódusok neve ugy kezdődik hogy test, pl `test_user_can_view_makers_index()`
- ilyesmi kell bele:
  ```php
   public function test_user_can_view_makers_index()
    {
        //create a few maker records in the database
        Maker::factory()->count(3)->create();
        //send get request to the index route
        $response = $this->get(route('makers')); //makers.indexnek megfelelő kell
        $response->assertStatus(200);
        //assert that the response view contains makers data?
        $response->assertViewHas('entities');
	}
```

kell még ha lesz factory:
```php
 use HasFactory;
```

kell még a az adatbázis frissítős sor
```php
database refresh vag valami ilyesmi
```
### MakerFactory
 `php artisan make:factory MakerFactory`
- kamu adatokat generál, `faker` függvény
	- ->name vagy ->numberbetween ésatöbbi, olyan adatot generél amilyet szeretnénk

```php
public function definition(): array
    {
        return [
            'name' => $this->faker->name, //adjust the data as neccessary
        ];
    }
```

ide írjuk hogy hogyan generálja a kamu adatokat ig

==végül kiderült hogy egyáltalán nem kell .env.testing és hozzá a db==
## (Új adatbázis létrehozása a teszteléshez)
nem akarjuk hogy az éles adatbázison fussanak a tesztek, ezért kell
### .env.testing kell
#### . lekopizzuk a .envet. 
- db connection sqlite
- db database = cars_test
	- ez még nem létezik, következő lépésben létrehozzuk

### Létrehozzuk az adatbázist
cmdből `c:\xampp\mysql\bin\mysql -u root `
(ha a path-hez hozzáadnánk lehetne csak mysql)
- create database cars_test




### Nézzük meg működik e
`vendor\bin\phpunit`
- a jól lefutott teszteket nem írja, csak ahol elakad.
`vendor\bin\phpunit --testdox`
- ez szépen kiírja hogy mi futott le, pl:

```cmd
Time: 00:00.461, Memory: 44.00 MB

Example (Tests\Feature\Example)
 ✔ The application returns a successful response

Example (Tests\Unit\Example)
 ✔ That true is true

Fuel Controller (Tests\Feature\FuelController)
 ✔ Example
 ✔ User can view fuel index
 ✔ User can create fuel
 ✔ User can update fuel
 ✔ User can delete fuel

Maker Controller (Tests\Feature\MakerController)
 ✔ Example

OK (8 tests, 20 assertions)
```

1. xamppot el kell indítani már ehhez, meg a szervert
- ott tartunk hogy az eslő assert lefut, a második (hogy megkapja e a makerst) hibát dob.
	- megoldás: a tesztben makers adatokat kerestünk, de a makercontroller fájlban entitiesnek definiáltuk. a tesztben is entitest kell keresni, és így működik.
- 



### Új teszt: `test_authenticated_user_can_create_maker()`

```php

public function test_authenticated_user_can_create_maker()

    {

  

        $makerData = ['name' => 'New Maker'];

  

        $response = $this->post(route('storeMaker'), $makerData); //makers.store-nek megfelelő

  

        $response->assertRedirect(route('makers'));

  

        //Assert that the response redirects to the makers indx route with a success

        $this->assertDatabaseHas('entities', $makerData);

        $response->assertSessionHas('success', 'New Maker sikeresen létrehozva'); //ugyanaz kell mint a makercontrollerbe

  

    }
```

ez, de nekem nincs meg hozzá a kód hogy működjön is

### Új teszt:


```php
    public function test_user_can_update_maker()

    {

  

        $maker = Maker::factory()->create();

  

        //Simulate an authenticated user

        // $this->actingAs(User::factory()->create());

  

        $updatedData = ['name' => 'Updated Maker'];

  

        $response = $this->patch(route('updateMakers', $maker->id), $updatedData);

  

        $response->assertRedirect(route('makers'));

  

        //Assert that the maker was updated in the database

        $this->assertDatabaseHas('entities', $updatedData);

        $response->assertRedirect(route('makers')); //lehet ez véletlenül van itt

        $response->assertSessionHas('success', 'Updated Maker sikeresen módosítva'); //ugyanaz kell mint a makercontrollerbe

  

    }
```


