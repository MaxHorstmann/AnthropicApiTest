const express = require('express');
const cors = require('cors');

const app = express();
const port = process.env.PORT || 3000;

// Middleware
app.use(cors());
app.use(express.json());

// Chat endpoint
app.post('/api/chat', async (req, res) => {
  try {
    const { message } = req.body;
    
    // Here you can integrate with any AI service or implement your own logic
    // For now, we'll just echo back a simple response
    const response = {
      text: `You said: ${message}`,
      sender: 'bot'
    };
    
    // Add artificial delay to simulate processing
    await new Promise(resolve => setTimeout(resolve, 1000));
    
    res.json(response);
  } catch (error) {
    console.error('Error processing chat message:', error);
    res.status(500).json({ error: 'Internal server error' });
  }
});

app.listen(port, () => {
  console.log(`Server is running on port ${port}`);
}); 