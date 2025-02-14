### [The Routes Directory](https://laravel.com/docs/11.x/structure#the-routes-directory)
Optionally, you may install additional route files for API routes (`api.php`) and broadcasting channels (`channels.php`), via the `install:api` and `install:broadcasting` Artisan commands.

The `api.php` file contains routes that are intended to be stateless, so requests entering the application through these routes are intended to be authenticated [via tokens](https://laravel.com/docs/11.x/sanctum) and will not have access to session state.

### [The Storage Directory](https://laravel.com/docs/11.x/structure#the-storage-directory)
The `storage/app/public` directory may be used to store user-generated files, such as profile avatars, that should be publicly accessible. You should create a symbolic link at `public/storage` which points to this directory. You may create the link using the `php artisan storage:link` Artisan command.

### [The Http Directory](https://laravel.com/docs/11.x/structure#the-http-directory)

The `Http` directory contains your controllers, middleware, and form requests. Almost all of the logic to handle requests entering your application will be placed in this directory.

### [The Models Directory](https://laravel.com/docs/11.x/structure#the-models-directory)

The `Models` directory contains all of your [Eloquent model classes](https://laravel.com/docs/11.x/eloquent). The Eloquent ORM included with Laravel provides a beautiful, simple ActiveRecord implementation for working with your database. Each database table has a corresponding "Model" which is used to interact with that table. Models allow you to query for data in your tables, as well as insert new records into the table.

# Frontend

### [PHP and Blade](https://laravel.com/docs/11.x/frontend#php-and-blade)

In the past, most PHP applications rendered HTML to the browser using simple HTML templates interspersed with PHP `echo` statements which render data that was retrieved from a database during the request:

```php
<div>   
<?php foreach ($users as $user): ?>    
Hello, <?php echo $user->name; ?>
<br />
<?php endforeach; ?>
</div>
```

In Laravel, this approach to rendering HTML can still be achieved using [views](https://laravel.com/docs/11.x/views) and [Blade](https://laravel.com/docs/11.x/blade). Blade is an extremely light-weight templating language that provides convenient, short syntax for displaying data, iterating over data, and more:

```php
<div>   
@foreach ($users as $user)  
Hello, {{ $user->name }} <br />    
@endforeach
</div>
```

When building applications in this fashion, form submissions and other page interactions typically receive an entirely new HTML document from the server and the entire page is re-rendered by the browser. Even today, many applications may be perfectly suited to having their frontends constructed in this way using simple Blade templates.

Within the Laravel ecosystem, the need to create modern, dynamic frontends by primarily using PHP has led to the creation of [Laravel Livewire](https://livewire.laravel.com/) and [Alpine.js](https://alpinejs.dev/).


### [First Steps](https://laravel.com/docs/11.x/lifecycle#first-steps)

The entry point for all requests to a Laravel application is the `public/index.php` file.All requests are directed to this file by your web server (Apache / Nginx) configuration

retrieves an instance of the Laravel application from `bootstrap/app.php`.Laravel itself is to create an instance of the application / [service container](https://laravel.com/docs/11.x/container).



## [Resource Controllers](https://laravel.com/docs/11.x/controllers#resource-controllers)

If you think of each Eloquent model in your application as a "resource", it is typical to perform the same sets of actions against each resource in your application. For example, imagine your application contains a `Photo` model and a `Movie` model. It is likely that users can create, read, update, or delete these resources.

Because of this common use case, Laravel resource routing assigns the typical create, read, update, and delete ("CRUD") routes to a controller with a single line of code. To get started, we can use the `make:controller` Artisan command's `--resource` option to quickly create a controller to handle these actions:

```cmd
php artisan make:controller PhotoController --resource
```

This command will generate a controller at `app/Http/Controllers/PhotoController.php`. The controller will contain a method for each of the available resource operations. Next, you may register a resource route that points to the controller:

```php
use App\Http\Controllers\PhotoController; 
Route::resource('photos', PhotoController::class);
```

This single route declaration creates multiple routes to handle a variety of actions on the resource. The generated controller will already have methods stubbed for each of these actions. Remember, you can always get a quick overview of your application's routes by running the `route:list` Artisan command.

You may even register many resource controllers at once by passing an array to the `resources` method:

```php
Route::resources([    'photos' => PhotoController::class,    'posts' => PostController::class,]);
```
#### [Specifying the Resource Model](https://laravel.com/docs/11.x/controllers#specifying-the-resource-model)

If you are using [route model binding](https://laravel.com/docs/11.x/routing#route-model-binding) and would like the resource controller's methods to type-hint a model instance, you may use the `--model` option when generating the controller:

```
php artisan make:controller PhotoController --model=Photo --resource
```

#### [Generating Form Requests](https://laravel.com/docs/11.x/controllers#generating-form-requests)

You may provide the `--requests` option when generating a resource controller to instruct Artisan to generate [form request classes](https://laravel.com/docs/11.x/validation#form-request-validation) for the controller's storage and update methods:

```
php artisan make:controller PhotoController --model=Photo --resource --requests
```
#### [Actions Handled by Resource Controllers](https://laravel.com/docs/11.x/controllers#actions-handled-by-resource-controllers)

| Verb      | URI                    | Action  | Route Name     |
| --------- | ---------------------- | ------- | -------------- |
| GET       | `/photos`              | index   | photos.index   |
| GET       | `/photos/create`       | create  | photos.create  |
| POST      | `/photos`              | store   | photos.store   |
| GET       | `/photos/{photo}`      | show    | photos.show    |
| GET       | `/photos/{photo}/edit` | edit    | photos.edit    |
| PUT/PATCH | `/photos/{photo}`      | update  | photos.update  |
| DELETE    | `/photos/{photo}`      | destroy | photos.destroy |

### [Partial Resource Routes](https://laravel.com/docs/11.x/controllers#restful-partial-resource-routes)

When declaring a resource route, you may specify a subset of actions the controller should handle instead of the full set of default actions:

```
use App\Http\Controllers\PhotoController; Route::resource('photos', PhotoController::class)->only([    'index', 'show']); Route::resource('photos', PhotoController::class)->except([    'create', 'store', 'update', 'destroy']);
```
#### [API Resource Routes](https://laravel.com/docs/11.x/controllers#api-resource-routes)

When declaring resource routes that will be consumed by APIs, you will commonly want to exclude routes that present HTML templates such as `create` and `edit`. For convenience, you may use the `apiResource` method to automatically exclude these two routes:
```php
use App\Http\Controllers\PhotoController;
use App\Http\Controllers\PostController;
Route::apiResources([

'photos' => PhotoController::class,

'posts' => PostController::class,

]);
```
### [Nested Resources](https://laravel.com/docs/11.x/controllers#restful-nested-resources)

Sometimes you may need to define routes to a nested resource. For example, a photo resource may have multiple comments that may be attached to the photo. To nest the resource controllers, you may use "dot" notation in your route declaration:

```
use App\Http\Controllers\PhotoCommentController; Route::resource('photos.comments', PhotoCommentController::class);
```

This route will register a nested resource that may be accessed with URIs like the following:

```
/photos/{photo}/comments/{comment}
```

#### [Shallow Nesting](https://laravel.com/docs/11.x/controllers#shallow-nesting)

Often, it is not entirely necessary to have both the parent and the child IDs within a URI since the child ID is already a unique identifier. When using unique identifiers such as auto-incrementing primary keys to identify your models in URI segments, you may choose to use "shallow nesting":

```
use App\Http\Controllers\CommentController; Route::resource('photos.comments', CommentController::class)->shallow();
```

This route definition will define the following routes:

|Verb|URI|Action|Route Name|
|---|---|---|---|
|GET|`/photos/{photo}/comments`|index|photos.comments.index|
|GET|`/photos/{photo}/comments/create`|create|photos.comments.create|
|POST|`/photos/{photo}/comments`|store|photos.comments.store|
|GET|`/comments/{comment}`|show|comments.show|
|GET|`/comments/{comment}/edit`|edit|comments.edit|
|PUT/PATCH|`/comments/{comment}`|update|comments.update|
|DELETE|`/comments/{comment}`|destroy|comments.destroy|