<?php

namespace Database\Seeders;

use App\Models\Kategoria;
use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;

class kategoriaSeeder extends Seeder
{
    /**
     * Run the database seeds.
     */
    const ITEMS = [
        'Ház', 'Lakás', 'Építési telek', 'Garázs', 'Mezőgazdasági terület', 'Ipari ingatlan'
    ];

    public function run(): void
    {
        foreach (self::ITEMS as $item) {
            $entity = new Kategoria(['nev' => $item]);
            $entity->save();
        }
    }
}
