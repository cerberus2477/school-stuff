
## Futtatás:
#### Minden futtatáshoz

- xampp elindítás
- ```php artisan serve```

#### Első letöltésnél

- ```composer update``` kell, az létrehozza a vendort.
- ```php artisan migrate```

- ```php artisan mysql:createdb cars```

## A projekt elkészítésének menete, jegyzet
### Project létrehozása és adatbázis létrehozása
laravel projekt létrehozása:
 `composer create-project laravel/laravel [project_name]`
####  1. htdocs mappában
- ``` composer create-project laravel/laravel autok ```
- ``` cd autok```

#### 2. .env fájlban adatbázis beállításainak módosítása
   - 22. sortól kb ne legyen kikommentelve, dbnamet adjuk meg és sqlite helyett mysql
``` php
DB_HOST=127.0.0.1
DB_PORT=3306
DB_DATABASE=cars
DB_USERNAME=root
DB_PASSWORD= 
```


#### 3. Létrehozunk egy adatbázis schemát
   stackoverflowt követjük: https://stackoverflow.com/questions/32191135/how-to-create-database-schema-table-in-laravel
   
 ``` php artisan make:command mysql ```
   - fill the content of App\Console\Commands\createdb.php, dropdb ugyanígy
   
```php
use Illuminate\Support\Facades\DB;


    protected $signature = 'mysql:createdb {name?}';
    protected $description = 'Create a new mysql database schema based on the database config file';
    public function __construct()
    {
        parent::__construct();
    }


    public function handle()
    {
        $schemaName = $this->argument('name') ?: config("database.connections.mysql.database");
        $charset = config("database.connections.mysql.charset",'utf8mb4');
        $collation = config("database.connections.mysql.collation",'utf8mb4_unicode_ci');

        config(["database.connections.mysql.database" => null]);

        $query = "CREATE DATABASE IF NOT EXISTS $schemaName CHARACTER SET $charset COLLATE $collation;";

        DB::statement($query);

        config(["database.connections.mysql.database" => $schemaName]);
    }
}
``` 



#### 4. CreateDb parancs
` php artisan mysql:createdb autok `

   - ezzel hozzuk létre ezeket a parancsokat a developereknek kb
fel is kell tölteni a fájlt xd



###  Migration (tábla) készítése
` php artisan make:migration create_[table_name]_table`
- A table_name legyen angolul és többes számban, pl bodies, makers stb.
- A $table->timestamps(); nem kell
#### foreign key pl
```php
 $table->foreign("makerId")->references('id')->on('makers');
```

###  Model (rekord) készítése
`` php artisan make:model [ModelName]`
- A ModelName legyen ugyanaz, mint ami a tábla neve volt, csak egyes számban, pl: Body, Maker stb
- Ha a $table->timestamps(); sort kivettük a migrációból, akkor a modellbe kell:
 `public $timestamps = false;`

### Controller (egy táblához tartozó requestek) készítése
`php artisan make:controller [ControllerName] --resource`
- A ControllerName legyen ugyanaz, mint a ModelName + Controller, pl: BodyController, MakerController

#### Controller példa
 * BodyController.php
```php
<?php

namespace App\Http\Controllers;

use App\Models\Body;
use App\Traits\ValidationRules;
use Illuminate\Http\Request;

class BodyController extends Controller
{
    use ValidationRules;
    /**
     * Display a listing of the resource.
     */
    public function index()
    {
        $bodies = Body::all();
        return view('body.index', compact('bodies'));
    }

    /**
     * Show the form for creating a new resource.
     */
    public function create()
    {
        return view('body.create');
    }

    /**
     * Store a newly created resource in storage.
     */
    public function store(Request $request)
    {
        $request->validate($this->getNameValidationRules());
        $body  = new Body();
        $body->name = $request->input('name');
        $body->save();

        return redirect()->route('bodies.index')->with('success', "{$body->name} sikeresen létrehozva");
    }

    /**
     * Display the specified resource.
     */
    public function show(string $id)
    {
        $body = Body::find($id);
        return view('body.show', compact('body'));
    }

    /**
     * Show the form for editing the specified resource.
     */
    public function edit(string $id)
    {
        $body = Body::find($id);
        return view('body.edit', compact('body'));
    }

    /**
     * Update the specified resource in storage.
     */
    public function update(Request $request, string $id)
    {
        $request->validate($this->getNameValidationRules());
        $body  = Body::find($id);
        $body->name = $request->input('name');
        $body->save();

        return redirect()->route('bodies.index')->with('success', "{$body->name} sikeresen módosítva");
    }

    /**
     * Remove the specified resource from storage.
     */
    public function destroy(string $id)
    {
        $body  = Body::find($id);
        $body->delete();

        return redirect()->route('bodies.index')->with('success', "Sikeresen törölve");
    }
}
```

==***a game-es projektben ez szebben meg van írva.***==

#### Validálás
- ***van róla a dokumentációban több***
- jó dolog validálni a bemenő dolgokat

validationrules.php - trait asszem, be kell useolni majd
```php
getNameValidationRules()

return
[
	['name' => 'requires|min:3|max:255',],
	[
	'name.min' => 'A megnevezés legalább 3 karakter hosszú kell legyen.',
	'name.max' => 'A megnevezés legalább 3 karakter hosszú kell legyen.'
	]
];
```


fuelcontroller.php
```php
public function store(){
	$request->validate($this->getNameValidationRules());
	$fuel = new Fuel();
	$fuel->name = $request->inpit('name');
}
```

updatenel is validate
```php
public function update(){
	$request->validate($this->getNameValidationRules());
	$fuel = Fuel::find($id);
	$fuel->name = $request->input('name');
	$fuel->save();

	return redirect()->route('fuels.index')->with('');
}

```
==***a game-es projektben ez szebben meg van írva.***==

##### Az input validálása esetén ki kell íratni a hibákat:

`php artisan make:view error`

```html
@if($errors->any())
    <div class="alert alert-warning">
        <ul>
            @foreach($errors->all() as $error)
                <li>{{ $error }}</li>
            @endforeach
        </ul>
    </div>
@endif
```

#### Siker
`php artisan make:view success`

```html
@if(session('success'))
    <div class="alert alert-success">
        {{ session('success') }}
    </div>
@endif

```
 

###  View-k készítése
```cmd
> php artisan make:view table_name.list
> vagy
> php artisan make:view table_name.index

> php artisan make:view table_name.create
> php artisan make:view table_name.edit

> php artisan make:view table_name.show
```
#### Create
 ## create.blade.php
```html
<!-- itt hozza be a layout.blade.php fájlt, ami a program frontendjének a kerete a menüvel, lábléccel stb. -->
@extends('layout')

<!-- ezt fogja betölteni a 'layout'-ba ebbe a részbe:
	<main>
		<!-- ide fogja behúzni a view-kat -->
        @yield('content')
    </main>
-->	
@section('content')
<h1>Új karosszéria</h1>
<div>
    <!-- Simplicity is the ultimate sophistication. - Leonardo da Vinci -->
	<!-- ide íratjuk ki a validációs hibákat -->
    @include('error')

    <form action="{{route('bodies.store')}}" method="post">
        @csrf
        <fieldset>
            <label for="name">Megnevezés</label>
            <input type="text" id="name" name="name">
        </fieldset>
        <button type="submit">Ment</button>
        <a href="{{ route('bodies.index') }}">Mégse</a>
    </form>
</div>
@endsection
```


#### Edit
-  edit.blade.php
```html
@extends('layout')
<div>
    <!-- Do what you can, with what you have, where you are. - Theodore Roosevelt -->
</div>
@section('content')
    <div>
        <!-- Simplicity is the ultimate sophistication. - Leonardo da Vinci -->
        @include('error')
        <form action="{{ route('bodies.update', $body->id) }}" method="post">
            @csrf
            @method('PATCH')
            <fieldset>
                <label for="name">Megnevezés</label>
                <input type="text" id="name" name="name" required value="{{ old('name', $body->name) }}">
            </fieldset>
            <button type="submit">Ment</button>
            <a href="{{ route('bodies.index') }}">Mégse</a>
        </form>
    </div>
@endsection
```


#### Index vagy List
 ## index.blade.php / list
 ```html
 @extends('layout')

@section('content')
<h1>Karosszériák</h1>
<div>
    <!-- Happiness is not something readymade. It comes from your own actions. - Dalai Lama -->
    @include('success')
    <a href="{{ route('bodies.create') }}" title="Új">Új hozzáadása</a>
	@foreach($bodies as $body)
		<div class="row {{ $loop->iteration % 2 == 0 ? 'even' : 'odd' }}">
			<div class="col id">{{ $body->id }}</div>
			<div class="col">{{$body->name}}</div>
			<div class="right">
				<div class="col"><a href="{{ route('bodies.show', $body->id) }}"><button><i class="fa fa-binoculars" title="Mutat"></i></button></a></div>
				<!-- Bejelentkezett felhasználó ellenőrzése, csak ha a breeze csomagot telepítettük -->
				@if(auth()->check())
					<div class="col"><a href="{{ route('bodies.edit', $body->id) }}"><button><i class="fa fa-edit edit" title="Módosít"></i></button></a></div>
					<div class="col">
						<form action="{{ route('bodies.destroy', $body->id) }}" method="POST">
							@csrf
							@method('DELETE')
							<button type="submit" name="btn-del-fuel"><i class="fa fa-trash-can trash" title="Töröl"></i></button>
						</form>
					</div>
				@endif
			</div>
		</div>
	@endforeach
</div>
@endsection
```


#### (show)
 * show.blade.php
 ```html
 @extends('layout')

@section('content')
    <h1>"{{ $body->name }}" karosszéria</h1>
    <div class="row">
        <div>{{ $body->id }}</div>
        <div>{{$body->name}}</div>
    </div>
@endsection 

```


### `Web.php`-ban a requestek megadása
routes/web.php
pl:
```php
Route::post('/bodies', [BodyController::class, 'store'])->name('bodies.store');
Route::get('/bodies/create', [BodyController::class, 'create'])->name('bodies.create');
Route::patch('/bodies/{body}', [BodyController::class, 'update'])->name('bodies.update');
Route::get('/bodies/{body}/edit', [BodyController::class, 'edit'])->name('bodies.edit');
Route::delete('/bodies/{body}', [BodyController::class, 'destroy'])->name('bodies.destroy');
Route::get('/bodies', [BodyController::class, 'index'])->name('bodies.index');
Route::get('/bodies/{body}', [BodyController::class, 'show'])->name('bodies.show');
```
 vagy, ami jobb
```cmd
php artisan make:controller PhotoController --resource
```

This command will generate a controller at `app/Http/Controllers/PhotoController.php`. The controller will contain a method for each of the available resource operations. Next, you may register a resource route that points to the controller:

```php
use App\Http\Controllers\PhotoController; 
Route::resource('photos', PhotoController::class);
```



### Kell egy `layout.blade.php`, ez a az oldal kerete

`php artisan make:view layout`

/***************************
 * layout.blade.php
 **/

```html
<!DOCTYPE html>
<html lang="hu">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Autók</title>

    <!-- Scripts -->
    <script src="{{ asset('js/app.js') }}" defer></script>
    <script src="{{ asset('js/jquery-3.7.1.js') }}"></script>
    <!-- Styles -->
    <link rel="stylesheet" href="{{ asset('css/style.css') }}">
    <link rel="stylesheet" type="text/css" href="{{ asset('fontawesome/css/all.css') }}" >

    <link rel="shortcut icon" href="{{ asset('favicon.png') }}" type="image/x-icon">
</head>

<body>
    <header>
            <nav>
                <ul>
                    <li><a href="{{ route('vehicles.index') }}">Járművek</a></li>
                    <li><a href="{{ route('makers.index') }}">Gyártók</a></li>
                    <li><a href="{{ route('models.index') }}">Modellek</a></li>
                    <li><a href="{{ route('trims.index') }}">Típusok</a></li>
                    <li><a href="{{ route('bodies.index') }}">Karosszériák</a></li>
                    <li><a href="{{ route('transmissions.index') }}">Sebváltók</a></li>
                    <li><a href="{{ route('fuels.index') }}">Üzemanyagok</a></li>
                    <!-- Login: csak ha sikerült feltenni a breeze csomagot -->
					@if(auth()->check())
                        <li>
                            <form class="logout" action="{{ route('logout') }}" method="post">
                                @csrf
                                <button type="submit">Kijelentkezés ({{ auth()->user()->name }})</button>
                            </form>
                        </li>
                    @else
                        <li><a href="{{ route('login') }}">Login</a></li>
                    @endif

                </ul>
            </nav>
         </header>
    <main>
		<!-- ide fogja behúzni a view-kat -->
        @yield('content')
    </main>

    <footer>
        <p>&copy; 2024 Tábor Tünde</p>
    </footer>

</body>
</html>

```

### Seeder létrehozása

`php artisan make:seeder BodySeeder`

 * BodySeeder.php

```php
<?php

namespace Database\Seeders;

use App\Models\Body;
use Illuminate\Database\Seeder;

class BodieSeeder extends Seeder
{
    const ITEMS = [
        'Crossover',
        'Fastback',
        'Hardtop',
        'Hatchback',
        'Kabrió',
        'Kombi',
        'Kupé',
        'Liftback',
        'Limuzin',
        'Minivan',
        'Pickup',
        'Roadster',
        'Szedán',
        'Targa',
    ];

    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
        foreach (self::ITEMS as $item) {
            $body = new Body();
			$body->name = $item;
            $body->save();
        }
    }
}
```
 


## Plusz dolgok
  
  ##### ==progressbar==t adunk a dokuból
  
```php
$bar = $this->output->createProgressBar(count($makers));

$bar->start();

foreach (...){
$bar->advance();
}

$bar->finish();
```
  
- adatbázis model*naming convention: model neve egyesszamban, tabla tobbesszamban*

- php.iniben
  ```xdebug.start_with_request = trigger``` -> nem lesz timeout

- csvből kitörölni az utolsó üres sort

- ```c:\xampp\mysql\bin\mysql -u root cars```

- xdebug felgyorsítása:

	- xdebug chrome kiegészítő
	- xdebug.start.with.request = triegger (yes helyett)