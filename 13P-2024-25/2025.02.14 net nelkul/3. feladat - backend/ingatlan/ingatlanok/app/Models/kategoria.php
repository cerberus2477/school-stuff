<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;

class kategoria extends Model
{
    public $timestamps = false;
    protected $fillable = [
        'kategoria', "leiras", "hirdetesDatuma", "tehermentes", "ar", "kepUrl"
    ];
}
