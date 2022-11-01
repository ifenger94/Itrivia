export class Utils {

    /**
     * Random number entre min y max, ambos extemos incluidos.
     * @param min 
     * @param max 
     */
    static randomNumber(min: number, max: number) {
        return Math.round(Math.random() * (max - min) + min);
    }

    /**
     * Barajea aleatoriamente un array
     * @param array 
     */
    static shuffleArray(array: any[]) {
        if (array.length <= 1) return array;

        for (let i = array.length - 1; i > 0; i--) {
            let indiceAleatorio = Math.floor(Math.random() * (i + 1));
            let temporal = array[i];
            array[i] = array[indiceAleatorio];
            array[indiceAleatorio] = temporal;
        }
    }
}