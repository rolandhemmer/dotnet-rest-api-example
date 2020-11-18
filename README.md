# .NET REST API Example

An example of a .NET REST API (with database)

## Table of contents

1. [Prerequisites](#prerequisites)
2. [Environment](#environment)  
   2.1. [Docker](#docker)  
   2.2. [.NET Core SDK](#net-core-sdk)
3. [Usage](#usage)

## 1. Prerequisites

- macOS, Linux or Windows 10
- 🐳 Docker
- Compatible IDE or editor
  - [Visual Studio](https://visualstudio.microsoft.com/vs/)
  - [Visual Studio Code](https://code.visualstudio.com/)
  - [Rider](https://www.jetbrains.com/rider/)
  - _hell, even Vim if you want..._

**[⬆ back to top](#table-of-contents)**

## 2. Environment

### 2.1. Docker

The [official Docker documentation](https://docs.docker.com/install/linux/docker-ce/ubuntu/) is simply wonderful. Follow the steps, and everything should be as smooth as possible.

⚠ **Make sure to read the "OS requirements" part first**. Not all Linux distrubtions are properly supported. Also, LTS versions are usually highly recommanded.

Once ready, [Docker Compose](https://docs.docker.com/compose/install/) is the next step. Please note that even if there's lot of differents installation options, the Python package is often the preferred option (for its ease-of-use and easy upgradability):

```bash
pip3 install docker-compose
```

⚠ This command might conflit with your existing Python installation. In that case, other installation ways should be preferred.

Use the following commands to make sure everything is correctly installed:

```bash
docker --version
docker-compose --version
```

**[⬆ back to top](#table-of-contents)**

#### 2.1.1 Additional Windows configuration

After Docker and Docker Compose, a Windows installation might require a little bit more of work: using the [Windows Subsystem for Linux](https://docs.microsoft.com/en-us/windows/wsl/install-win10).

> The Windows Subsystem for Linux lets developers run a GNU/Linux environment -- including most command-line tools, utilities, and applications -- directly on Windows, unmodified, without the overhead of a virtual machine.

Use the previous link to get started with this truly life-changing Windows feature.

Then, follow these few configuration steps to connect your new Linux terminal to Docker:

- Expose the Docker deamon without TLS:
- Share your disk drives to Docker:
- Install Docker on your Linux subsystem (see [2.1. Docker](#docker))
- Connect your Linux installation to your Windows Docker instance:

```bash
export DOCKER_HOST=tcp://localhost:2375

# To avoid entering this line at every shell launch, add it to your .profile, .bashrc or your preferred shell startup configuration.
```

- Finally, create the Linux file `/etc/wsl.conf` (as sudo), and enter this content:

```bash
[automount]
root = /
options = "metadata"
```

This will change your Windows disk mount point from `/mnt/<disk_letter>` to `/<disk_letter>` (i.e: `/mnt/c` to `/c`).

Several system reboots might be required for some steps.

**[⬆ back to top](#table-of-contents)**

### 2.2. .NET Core SDK

The [official .NET Core documentation](https://docs.microsoft.com/en-us/dotnet/core/install/sdk) is also very detailled. Use the radio menu below the title to choose your OS.

Use the following commands to make sure everything is correctly installed:

```bash
dotnet --version
```

**[⬆ back to top](#table-of-contents)**

## 3. Usage

The repository is Docker-based: from a clean installation, simply run `docker-compose up` to build and run the sample API.

Default port is `8080`.

### 3.1. Run options

Docker compose supports various options and arguments.  
See the [compose documentation](https://docs.docker.com/compose/gettingstarted/) for more.

**[⬆ back to top](#table-of-contents)**
