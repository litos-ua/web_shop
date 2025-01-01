


FROM node:20
#FROM node:16.17.0

# Set a working directory
WORKDIR /srv/src/app

# Copy only the package files first to leverage Docker cache
COPY package*.json ./

# Switch to root to install dependencies
USER root

# Install dependencies and global tools
# Install dependencies as root
USER root
RUN apt-get update && apt-get install -y \
    vim \
    zip \
    unzip \
    curl

# Change ownership of the working directory to the 'node' user
RUN chown -R node:node /srv/src/app

# Switch back to the 'node' user
USER node

# Copy the rest of the application code
COPY . .

# Build the React app for production
# RUN npm run build

# Expose the necessary port
EXPOSE 3000

# Command to run the production server
# CMD ["serve", "-s", "build"]
# CMD ["npm", "run", "dev", "--", "--host"]
CMD ["tail", "-f", "/dev/null"]


