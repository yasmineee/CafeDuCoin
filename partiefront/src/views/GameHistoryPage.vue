<template>
    <div>
        <h1>Game History for {{ game.name }}</h1>
        <ul>
            <li v-for="history in gameHistories" :key="history.id">
                {{ history.state }} At:
                {{ history.state === 'Returned' ? history.formattedReturnDate :  history.formattedBorrowDate }}
                {{game.currentState =history.state }}
            </li>
        </ul>
        
        <button v-if="game && (game.currentState === 'Free' || game.currentState === 'Returned')" @click="borrowGame">Borrow Game</button>
        <button v-else-if="game && game.currentState === 'Borrowed'" @click="returnGame">Return Game</button>

    </div>
    
</template>

<script>
import axios from 'axios';

export default {
    name: 'GameHistoryPage',
    props: {
        id: {
            type: Number,
            required: true
        }
    },
    data() {
        return {
            game: {},
            gameHistories: []
        };
    },
    mounted() {
        this.fetchGameHistory();
    },
    methods: {
        async fetchGameHistory() {
            try {
                const gameResponse = await axios.get(`http://localhost:5000/api/game/${this.id}`);
                this.game = gameResponse.data;

                const historyResponse = await axios.get(`http://localhost:5000/api/gamehistory/history/${this.id}`);
                this.gameHistories = historyResponse.data;
            } catch (error) {
                console.error('Error fetching game history:', error);
            }
        },
        async borrowGame() {
            try {
                console.log("we click to borrow"); 
                await axios.post(`http://localhost:5000/api/gamehistory/borrow/${this.id}`);
                console.log("borrowed"); 
                this.fetchGameHistory();
            } catch (error) {
                console.error("There was an error borrowing the game:", error);
            }
        },
        async returnGame() {
            try {
                console.log("we click to return");
                await axios.post(`http://localhost:5000/api/gamehistory/return/${this.id}`);
                console.log("returned");
                this.fetchGameHistory();
            } catch (error) {
                console.error("There was an error returning the game:", error);
            }
        },
    }
};
</script>
