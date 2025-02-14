<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;
use Carbon\Carbon;

return new class extends Migration
{
    /**
     * Run the migrations.
     */
    public function up(): void
    {
        Schema::create('ingatlanok', function (Blueprint $table) {
            $table->id();
            //kategoria fk int not nullable
            $table->integer("kategoria");
            $table->foreign("kategoria")->references('id')->on('kategoriak');
            $table->string("nev")->unique()->nullable(false);
            $table->string("leiras");
            $table->date("hirdetesDatuma")->default(Carbon::now());
            $table->boolean("tehermentes")->nullable(false);
            $table->integer("ar")->nullable(false);
            $table->string("kepUrl");
        });
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        Schema::dropIfExists('ingatlanok');
    }
};
